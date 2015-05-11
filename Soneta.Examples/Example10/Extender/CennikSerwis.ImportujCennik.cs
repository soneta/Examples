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
                using (var writer = new StringWriter()) {
                    tcsvw.Write(writer);
                    result = writer.ToString();
                }
            }
            catch (Exception exc) {
                result = exc.Message;
            }
            return result;
        }

        private SessionCsvWriter initCsvWriter() {
            var data = initDatasource();
            var accessor = new AccessorContext {
                Context = Context.Empty.Clone(_session),
                MemberType = data.GetRowType()
            };

            var tsvw = new SessionCsvWriter {
                HeaderMode = CsvWriterHeaderMode.Path,
                DataSource = data,
                Accessors = new List<Accessor> {
                    accessor.GetAccessor("Kod"),
                    accessor.GetAccessor("Ceny.Podstawowa.Netto")
                }
            };

            foreach (var acc in tsvw.Accessors)
                acc.Prepare();

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
