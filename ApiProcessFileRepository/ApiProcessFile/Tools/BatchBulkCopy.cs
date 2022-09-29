

using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace ApiProcessFile.Tools
{
    public class BatchBulkCopy
    {
   
        public void BatchBulkMethod(DataTable dataTable, string tablaDestinoNombre, int batchSize)
        {
            // Get the DataTable 
            DataTable dtInsertRows = dataTable;
            
            using (SqlBulkCopy sbc = new SqlBulkCopy(@"Data source=DESKTOP-PL1O4IL\\SQLEXPRESS;Initial Catalog=CajaSurquillo1;security integrated=true", SqlBulkCopyOptions.Default))
            {
                sbc.DestinationTableName = tablaDestinoNombre;

                // Number of records to be processed in one go
                sbc.BatchSize = batchSize;

                // Add your column mappings here
                sbc.ColumnMappings.Add("IdCardRequest", "IdCardRequest");
                sbc.ColumnMappings.Add("IdMasterModeOfDelivery", "IdMasterModeOfDelivery");
                sbc.ColumnMappings.Add("DeliveryAddress", "DeliveryAddress");
                sbc.ColumnMappings.Add("IdMasterAgencyOfDelivery", "IdMasterAgencyOfDelivery");
                sbc.ColumnMappings.Add("DeliveryDate", "DeliveryDate");
                sbc.ColumnMappings.Add("IdMasterCardType", "IdMasterCardType");
                sbc.ColumnMappings.Add("IdMasterSecurityType", "IdMasterSecurityType");
                sbc.ColumnMappings.Add("DesgravamentValue", "DesgravamentValue");
                sbc.ColumnMappings.Add("IdMasterCreditRisk", "IdMasterCreditRisk");
                sbc.ColumnMappings.Add("IdProduct", "IdProduct");
                sbc.ColumnMappings.Add("CardDisposition", "CardDisposition");
                sbc.ColumnMappings.Add("PurchaseAbroad", "PurchaseAbroad");
                sbc.ColumnMappings.Add("PuchaseOnline", "PuchaseOnline");
                sbc.ColumnMappings.Add("Create", "Create");
                sbc.ColumnMappings.Add("CreateBy", "CreateBy");
                sbc.ColumnMappings.Add("Modified", "Modified");
                sbc.ColumnMappings.Add("LastModififiedBy", "LastModififiedBy");
                sbc.ColumnMappings.Add("RecordStatus", "RecordStatus");
                sbc.ColumnMappings.Add("IdMasterFlowStatus", "IdMasterFlowStatus");
                // Finally write to server
                sbc.WriteToServer(dtInsertRows);
            }
            
        }

    }
}
