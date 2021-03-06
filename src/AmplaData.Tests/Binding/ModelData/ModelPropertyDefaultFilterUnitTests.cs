﻿using AmplaData.Attributes;
using NUnit.Framework;

namespace AmplaData.Binding.ModelData
{
    [TestFixture]
    public class ModelPropertyDefaultFilterUnitTests : TestFixture
    {
        [AmplaLocation(Location = "Enterprise")]
        [AmplaModule(Module = "Production")]
        [AmplaDefaultFilters("Sample Period=Current Shift", "Confirmed=True")]
        public class ModelWithDefaultFilter
        {
            public string Location { get; set; }
        }

        [AmplaLocation(Location = "Enterprise")]
        [AmplaModule(Module = "Production")]
        public class ModelWithNoDefaultFilter
        {
            public string Location { get; set; }
        }

        [Test]
        public void GetDefaultFilters()
        {
            ModelProperties<ModelWithNoDefaultFilter> modelProperties = new ModelProperties<ModelWithNoDefaultFilter>();

            Assert.That(modelProperties.DefaultFilters, Is.Empty);
        }



    }
}