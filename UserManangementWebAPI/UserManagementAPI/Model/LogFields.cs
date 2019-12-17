using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementAPI.Model
{
    public class LogFields
    {
        public string Component { get; set; }
        public int? TemplateId { get; set; }
        public string TrackingNumber { get; set; }
        public int? InstructionId { get; set; }
        //This helps with uniquely identifying a log type
        public string[] Fingerprint { get; set; }



        public LogFields()
        {
        }

        public LogFields(string component, int? templateId, string trackingNumber)
        {
            Component = component;
            TemplateId = templateId;
            TrackingNumber = trackingNumber;
        }

        public static LogFields LogByComponent(string component)
        {
            return new LogFields(component, null, null);
        }

        public static LogFields LogByTrackingNumber(string trackingNumber)
        {
            return new LogFields(null, null, trackingNumber);
        }
        public static LogFields LogByTemplateId(int templateId)
        {
            return new LogFields(null, templateId, null);
        }


        internal void SetFields()
        {
            MappedDiagnosticsContext.Set("Component", Component);
            MappedDiagnosticsContext.Set("TemplateId", TemplateId);
            MappedDiagnosticsContext.Set("TrackingNumber", TrackingNumber);
            MappedDiagnosticsContext.Set("InstructionId", Fingerprint);
            MappedDiagnosticsContext.Set("Fingerprint", Fingerprint);
        }

        internal void ResetFields()
        {
            MappedDiagnosticsContext.Set("Component", null);
            MappedDiagnosticsContext.Set("TemplateId", null);
            MappedDiagnosticsContext.Set("TrackingNumber", null);
            MappedDiagnosticsContext.Set("Fingerprint", null);
            MappedDiagnosticsContext.Set("InstructionId", null);
        }

    }
}
