using ApiProcessFile.Interfaces;
using ApiProcessFile.Models;
using ApiProcessFile.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiProcessFile.Service
{
    public class ProcessFileService : IProcessFile
    {
        private readonly ITramaPosition tramaPosition;
        public ProcessFileService(ITramaPosition tramaPosition)
        {
            this.tramaPosition = tramaPosition;
        }


        public async void GetProcessFiles()
        {
            List<TramaPosition> columnList = await tramaPosition.GetTramaPosition();
            var PathToProcess = @"C:\2019\Sample.txt";
            String[] lineasTxt = System.IO.File.ReadAllLines(PathToProcess);


            List<CardRequestProcess> ListToProcess = new List<CardRequestProcess>();
            
            //logica de lectura desde un archivo delimitado (trama generada)
            

            foreach (String linea in lineasTxt)
            {

                int start = 0;
                CardRequestProcess cardRequestColumn = new CardRequestProcess();

                for (int i = 0; i < columnList.Count; i++)
                {
                    var typeValue = columnList[i].TypeValue;
                   
                    var properties = cardRequestColumn.GetType().GetProperties();

                    SetPropertyValue(typeValue, linea, start, columnList[i], cardRequestColumn);

                    start = start + columnList[i].fullSpacePosition;

                }

                ListToProcess.Add(cardRequestColumn);

            }

            String tablaDestinoNombre = "NewtblCardRequest";

            System.Data.DataTable dt = ConvertToList.ToDataTable<CardRequestProcess>(ListToProcess, tablaDestinoNombre);

            new BatchBulkCopy().BatchBulkMethod(dt, tablaDestinoNombre, 99999);

            // fin de logica de Angel
        }


        private void SetPropertyValue(string typeValue,
            String linea,int start, TramaPosition columnList, CardRequestProcess cardRequestColumn)
        {
            CardRequestProcess X = new CardRequestProcess();

            if (typeValue == "N")
            {
                var valor = Convert.ToInt32(linea.Substring(start, columnList.fullSpacePosition));

                Type type = X.GetType();
                PropertyInfo prop = type.GetProperty(columnList.TramaName);
                prop.SetValue(X, valor, null);
 
            }
            else
            {
                var valor = Convert.ToString(linea.Substring(start, columnList.fullSpacePosition));

                PropertyInfo c = cardRequestColumn.GetType().GetProperties().Single(pi => pi.Name == columnList.TramaName);
                c.SetValue(valor, null);
            }

        }

    }
        
    
}
