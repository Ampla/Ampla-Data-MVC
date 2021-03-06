﻿using AmplaData.Attributes;
using AmplaData.Binding.ModelData;
using NUnit.Framework;

namespace AmplaData.Binding.Mapping
{
    [TestFixture]
    public class IdFieldMappingUnitTests : TestFixture
    {
        [AmplaLocation("Enterprise.Site.Point")]
        [AmplaModule("Production")]
        public class Model
        {
            public int Id { get; set; }
        }

        [Test]
        public void IdFieldMappingResolveValue()
        {
            IdFieldMapping fieldMapping = new IdFieldMapping("Id");

            Model model = new Model {Id = 100};

            ModelProperties<Model> modelProperties = new ModelProperties<Model>();

            string value;
            Assert.That(fieldMapping.TryResolveValue(modelProperties, model, out value), Is.True);
            Assert.That(value, Is.EqualTo("100"));
        }

        [Test]
        public void IdFieldMappingResolveValueZero()
        {
            IdFieldMapping fieldMapping = new IdFieldMapping("Id");

            Model model = new Model {Id = 0};

            ModelProperties<Model> modelProperties = new ModelProperties<Model>();

            string value;
            Assert.That(fieldMapping.TryResolveValue(modelProperties, model, out value), Is.False);
            Assert.That(value, Is.EqualTo(null));
        }

        [Test]
        public void CanWrite()
        {
            IdFieldMapping fieldMapping = new IdFieldMapping("Id");
            Assert.That(fieldMapping.CanWrite, Is.False);
        }
    }
}