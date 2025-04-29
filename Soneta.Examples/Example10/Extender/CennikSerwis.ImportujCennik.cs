using System;
using System.Collections.Generic;
using System.IO;
using Soneta.Business;
using Soneta.Towary;

namespace Soneta.Examples.Example10.Extender {

    public partial class CennikSerwis {

        public string ImportujCennik() {
            string result;
            try {
                var tcsvw = initCsvWriter();
                using var stream = new MemoryStream();
                using var reader = new StreamReader(stream);
                tcsvw.Write(stream);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                result = reader.ReadToEnd();
            }
            catch (Exception exc) {
                result = exc.Message;
            }
            return result;
        }

        private SessionDataWriter initCsvWriter() {
            var data = initDatasource();
            var accessor = new AccessorContext {
                Context = Context.Empty.Clone(_session),
                MemberType = data.GetRowType()
            };

            var tsvw = new SessionDataWriter {
                Session = _session,
                HeaderMode = WriterHeaderMode.Path,
                Format = SessionDataWriterFormat.Csv,
                DataSource = data,
                Columns = [ new SessionDataWriter.Column(accessor.GetAccessor("Kod"), "Kod"),
                            new SessionDataWriter.Column(accessor.GetAccessor("Ceny.Podstawowa.Netto"), "Netto") ]
            };

            return tsvw;
        }

        private SubTable initDatasource() {
            var tm = TowaryModule.GetInstance(_session);
            var tkey = tm.Towary.PrimaryKey;
            var condition = RowCondition.Empty;
            condition &= new FieldCondition.Equal("Typ", TypTowaru.Towar);
            condition &= new FieldCondition.Equal("Features.Synchronizowany", true);
            return tkey[condition];
        }
    }
}
