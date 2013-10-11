﻿using System;
using System.Collections.Generic;
using AmplaWeb.Data.Binding.MetaData;
using AmplaWeb.Data.Binding.ViewData;

namespace AmplaWeb.Data.Binding.Mapping.Modules
{
    public class StandardModuleMapping : IModuleMapping
    {
        protected StandardModuleMapping()
        {
            AddRequiredMapping("Id", () => new IdFieldMapping("Id"));
            AddRequiredMapping("ObjectId", () => new ReadOnlyFieldMapping("Location"));
        }

        protected void AddSpecialMapping(string field, Func<FieldMapping> fieldMappingFunc)
        {
            specialMappingFuncs[field] = fieldMappingFunc;
        }

        protected void AddRequiredMapping(string field, Func<FieldMapping> fieldMappingFunc)
        {
            requiredMappingFuncs[field] = fieldMappingFunc;
        }

        protected static bool StringIsNotNullOrEmpty(string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        protected static bool IsValidIdValue(string value)
        {
            int i;
            return !string.IsNullOrEmpty(value) && int.TryParse(value, out i) && i > 0;
        }
        
        private readonly Dictionary<string, Func<FieldMapping>> specialMappingFuncs = new Dictionary<string, Func<FieldMapping>>();
        private readonly Dictionary<string, Func<FieldMapping>> requiredMappingFuncs = new Dictionary<string, Func<FieldMapping>> ();

        protected static string Iso8601UtcNow()
        {
            return new Iso8601DateTimeConverter().ConvertToInvariantString(DateTime.UtcNow);
        }

        public FieldMapping GetFieldMapping(ViewField field, bool isModelField)
        {
            FieldMapping fieldMapping = null;
            if (isModelField)
            {
                Func<FieldMapping> fieldMappingFunc;
                if (specialMappingFuncs.TryGetValue(field.Name, out fieldMappingFunc))
                {
                    return fieldMappingFunc();
                }
                if (field.ReadOnly)
                {
                    fieldMapping = new ReadOnlyFieldMapping(field.DisplayName);
                }
                else
                {
                    fieldMapping = new ModelFieldMapping(field.DisplayName);
                }
            }
            else
            {
                Func< FieldMapping> fieldMappingFunc;
                if (requiredMappingFuncs.TryGetValue(field.Name, out fieldMappingFunc))
                {
                    return fieldMappingFunc();
                }
            }

            return fieldMapping;
        }
    }
}