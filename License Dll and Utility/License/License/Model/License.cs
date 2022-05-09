using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace License.Model
{
    [DataContract]
    public class LicenseInfo
    {
        [DataMember]
        public int idLicense { get; set; }
        [DataMember]
        public DateTime ValidFrom { get; set; }
        [DataMember]
        public DateTime ValidTo { get; set; }
        [DataMember]
        public DateTime? ActivationDate { get; set; }
        [DataMember]
        public string ActivationKey { get; set; }
        [DataMember]
        public String LicenseFile { get; set; }
        [DataMember]
        public String LicenseHash { get; set; }
        [DataMember]
        public int OrganizationId { get; set; }
        [DataMember]
        public string OrganizationName { get; set; }
        [DataMember]
        public bool IsActivated { get; set; }
        [DataMember]
        public bool IsExpired { get; set; }
        [DataMember]
        public bool IsTampered { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public DateTime? ModifiedDate { get; set; }
        [DataMember]
        public int? CreatedById { get; set; }
        [DataMember]
        public int? ModifiedById { get; set; }
    }

    [DataContract]
    public class ClientLicenseInfo
    {
        [DataMember]
        public int idLicense { get; set; }
        [DataMember]
        public DateTime ValidFrom { get; set; }
        [DataMember]
        public DateTime ValidTo { get; set; }
        [DataMember]
        public DateTime? ActivationDate { get; set; }
        [DataMember]
        public int OrganizationId { get; set; }
        [DataMember]
        public bool IsActivated { get; set; }
        [DataMember]
        public bool IsExpired { get; set; }
        [DataMember]
        public bool IsTampered { get; set; }
        [DataMember]
        public bool IsValidLicense { get; set; }
        [DataMember]
        public string Message { get; set; }

    }
}
