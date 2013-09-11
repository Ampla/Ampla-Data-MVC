﻿using AmplaWeb.Data.AmplaData2008;
using AmplaWeb.Data.Tests;
using NUnit.Framework;

namespace AmplaWeb.Data.Attributes
{
    [TestFixture]
    public class AmplaModuleAttributeUnitTests : TestFixture
    {
        [AmplaModule(Module = "Production")]
        public class ModelWithModule
        {
        }

        [AmplaModule]
        public class ModelWithNoModule
        {
        }

        [AmplaModule(Module = "")]
        public class ModelWithEmptyModule
        {
        }

        [AmplaModule("Production")]
        public class ModelModuleViaConstructor
        {
        }

        [AmplaModule(Module = "Invalid")]
        public class ModelWithInvalidModule
        {
        }

        public class ModelNoAttribute
        {
        }

        [Test]
        public void TryGetWithModule()
        {
            AmplaModules? module;
            bool result = AmplaModuleAttribute.TryGetModule<ModelWithModule>(out module);

            Assert.That(module, Is.EqualTo(AmplaModules.Production));
            Assert.That(result, Is.True);
        }

        [Test]
        public void TryGetWithNoModule()
        {
            AmplaModules? module;
            bool result = AmplaModuleAttribute.TryGetModule<ModelWithNoModule>(out module);

            Assert.That(module, Is.EqualTo(null));
            Assert.That(result, Is.False);
        }

        [Test]
        public void TryGetWithNoAttribute()
        {
            AmplaModules? module;
            bool result = AmplaModuleAttribute.TryGetModule<ModelNoAttribute>(out module);

            Assert.That(module, Is.EqualTo(null));
            Assert.That(result, Is.False);
        }

        [Test]
        public void TryGetWithEmptyAttribute()
        {
            AmplaModules? module;
            bool result = AmplaModuleAttribute.TryGetModule<ModelWithEmptyModule>(out module);

            Assert.That(module, Is.EqualTo(null));
            Assert.That(result, Is.False);
        }

        [Test]
        public void TryGetWithConstructorModule()
        {
            AmplaModules? module;
            bool result = AmplaModuleAttribute.TryGetModule<ModelModuleViaConstructor>(out module);

            Assert.That(module, Is.EqualTo(AmplaModules.Production));
            Assert.That(result, Is.True);
        }

        [Test]
        public void TryGetWithInvalidAttribute()
        {
            AmplaModules? module;
            bool result = AmplaModuleAttribute.TryGetModule<ModelWithInvalidModule>(out module);

            Assert.That(module, Is.EqualTo(null));
            Assert.That(result, Is.False);
        }
    }
}