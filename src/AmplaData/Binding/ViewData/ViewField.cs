﻿using System;
using System.ComponentModel;
using AmplaData.AmplaData2008;
using AmplaData.Binding.MetaData;

namespace AmplaData.Binding.ViewData
{
    public class ViewField
    {

        public ViewField(GetViewsField field)
        {
            Name = field.name;
            DisplayName = field.displayName;
            Required = field.required;
            ReadOnly = field.readOnly;
            DataType = DataTypeHelper.GetDataType(field.type);
            TypeConverter = TypeDescriptor.GetConverter(DataType);
        }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public bool Required { get; set; }

        public bool ReadOnly { get; set; }

        public Type DataType { get; set; }

        public TypeConverter TypeConverter { get; set; }
    }
}