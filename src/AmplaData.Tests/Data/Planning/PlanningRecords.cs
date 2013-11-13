﻿using System;
using AmplaData.Data.Records;

namespace AmplaData.Data.Planning
{
    public static class PlanningRecords
    {
        private static int _recordId = 100;

        public static InMemoryRecord NewRecord()
        {
            InMemoryRecord record = new InMemoryRecord { Location = "Enterprise.Site.Area.Planning", Module = "Planning" };
            record.SetFieldValue("IsManual", false);
            record.SetFieldValue("Deleted", false);
            DateTime now = DateTime.Now.TrimToSeconds();
            record.SetFieldValue("Planned Start Time", now);
            record.SetFieldValue("Planned End Time", now.AddHours(1));
            record.SetFieldValue("ActivityId", "New Activity Id");
            record.RecordId = _recordId++;
            return record;
        }
    }
}