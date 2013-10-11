﻿using System;
using AmplaWeb.Data.AmplaRepository;
using AmplaWeb.Data.Records;
using AmplaWeb.Data.Views;
using NUnit.Framework;

namespace AmplaWeb.Data.Downtime
{
    [TestFixture]
    public class DowntimeAmplaRepositoryUnitTests : AmplaRepositoryTestFixture<SimpleDowntimeModel>
    {
        private const string module = "Downtime";
        private const string location = "Enterprise.Site.Area.Point";

        public DowntimeAmplaRepositoryUnitTests() : base(module, location, DowntimeViews.StandardView)
        {
        }

        [Test]
        public void SubmitWithNullFields()
        {
            SimpleDowntimeModel model = new SimpleDowntimeModel
                {
                    Location = location,
                    StartTime = DateTime.Now,
                    CauseLocation = null,
                    Cause = null,
                    Classification = null
                };
            Repository.Add(model);

            Assert.That(model.Id, Is.GreaterThan(0));

            Assert.That(Records, Is.Not.Empty);

            InMemoryRecord record = Records[0];
            Assert.That(record.Location, Is.EqualTo(location));
            Assert.That(record.Module, Is.EqualTo(module));
            Assert.That(record.GetFieldValue("Start Time", DateTime.MinValue), Is.GreaterThan(DateTime.MinValue));
            Assert.That(record.Find("Cause Location"), Is.Null);
            Assert.That(record.Find("Cause"), Is.Null);
            Assert.That(record.Find("Classification"), Is.Null);
        }

        [Test]
        public void SubmitWithValidCauseLocation()
        {
            SimpleDowntimeModel model = new SimpleDowntimeModel { Location = location, StartTime = DateTime.Now, CauseLocation = "Enterprise.Site" };
            Repository.Add(model);

            Assert.That(model.Id, Is.GreaterThan(0));

            Assert.That(Records, Is.Not.Empty);

            InMemoryRecord record = Records[0];
            Assert.That(record.Location, Is.EqualTo(location));
            Assert.That(record.Module, Is.EqualTo(module));
            Assert.That(record.GetFieldValue("Start Time", DateTime.MinValue), Is.GreaterThan(DateTime.MinValue));
            Assert.That(record.GetFieldValue("Cause Location", string.Empty), Is.EqualTo("Enterprise.Site"));
        }

        /// <summary>
        /// Cause will read the value as string but will only write as a int
        /// </summary>
        [Test]
        public void SubmitWithCauseAsString()
        {
            SimpleDowntimeModel model = new SimpleDowntimeModel { Location = location, StartTime = DateTime.Now, Cause = "Broken"};
            Repository.Add(model);

            Assert.That(model.Id, Is.GreaterThan(0));

            Assert.That(Records, Is.Not.Empty);

            InMemoryRecord record = Records[0];
            Assert.That(record.Location, Is.EqualTo(location));
            Assert.That(record.Find("Cause"), Is.Null);
        }

        [Test]
        public void SubmitWithClassificationAsString()
        {
            SimpleDowntimeModel model = new SimpleDowntimeModel { Location = location, StartTime = DateTime.Now, Classification = "Unplanned Process" };
            Repository.Add(model);

            Assert.That(model.Id, Is.GreaterThan(0));

            Assert.That(Records, Is.Not.Empty);

            InMemoryRecord record = Records[0];
            Assert.That(record.Location, Is.EqualTo(location));
            Assert.That(record.Find("Classification"), Is.Null);
        }

        [Test]
        public void DefaultStartTime()
        {
            SimpleDowntimeModel model = new SimpleDowntimeModel { Location = location};
            Repository.Add(model);

            Assert.That(model.Id, Is.GreaterThan(0));

            Assert.That(Records, Is.Not.Empty);

            InMemoryRecord record = Records[0];
            Assert.That(record.Location, Is.EqualTo(location));
            Assert.That(record.Find("Sample Period"), Is.Null);
            Assert.That(record.GetFieldValue("Start Time", DateTime.MinValue), Is.Not.EqualTo(DateTime.MinValue));
        }

    }
}