﻿using System;
using System.Collections.Generic;
using System.Xml;
using AmplaData.AmplaData2008;
using AmplaData.Binding.MetaData;
using AmplaData.Binding.ModelData;
using AmplaData.Binding.ViewData;
using AmplaData.Records;

namespace AmplaData.Binding
{
    public class AmplaGetDataRecordBinding<TModel> : IAmplaBinding where TModel : new()
    {
        private readonly GetDataResponse response;
        private readonly List<AmplaRecord> records;
        private readonly IModelProperties<TModel> modelProperties;
        private readonly IAmplaViewProperties<TModel> amplaViewProperties;

        public AmplaGetDataRecordBinding(GetDataResponse response, List<AmplaRecord> records, IModelProperties<TModel> modelProperties, IAmplaViewProperties<TModel> amplaViewProperties)
        {
            this.response = response;
            this.records = records;
            this.modelProperties = modelProperties;
            this.amplaViewProperties = amplaViewProperties;
        }

        public bool Bind()
        {
            if (response.RowSets.Length == 0) return false;

            RowSet rowSet = response.RowSets[0];

            foreach (Row row in rowSet.Rows)
            {
                AmplaRecord model = new AmplaRecord(Convert.ToInt32(row.id))
                    {
                        Module = modelProperties.Module.ToString(),
                        ModelName = modelProperties.GetModelName()
                    };

                foreach (var column in rowSet.Columns)
                {
                    model.AddColumn(column.displayName, DataTypeHelper.GetDataType(column.type));
                }
                
                foreach (XmlElement cell in row.Any)
                {
                    string field = XmlConvert.DecodeName(cell.Name);
                    string value = cell.InnerText;
                    model.SetValue(field, value);
                }

                model.SetMappedProperties(amplaViewProperties.GetFieldMappings());
                records.Add(model);
            }
            return true;
        }

        public bool Validate()
        {
            return true;
        }
    }
}