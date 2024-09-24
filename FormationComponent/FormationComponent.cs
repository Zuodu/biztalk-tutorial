using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Message.Interop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationComponent
{
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [ComponentCategory(CategoryTypes.CATID_Validate)]
    [ComponentCategory(CategoryTypes.CATID_Any)]
    [System.Runtime.InteropServices.Guid("E3480923-3A6C-41D2-B8D7-3B8D43D22530")]
    public class FormationComponent : IBaseComponent, IComponent, IComponentUI, IPersistPropertyBag
    {
        public string Name => "Formation rename Component";

        public string Version => "1.0.0.0";

        public string Description => "Test Component for Formation";

        public string NewFileName { get; set; }

        public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            pInMsg.Context.Write("ReceivedFileName", "http://schemas.microsoft.com/BizTalk/2003/file-properties", NewFileName);

            return pInMsg; // Retourner le message modifié avec le nouveau nom de fichier
        }

        public IEnumerator Validate(object projectSystem)
        {
            throw new NotImplementedException();
        }

        public IntPtr Icon => IntPtr.Zero;

        // IPersistPropertyBag implementation
        public void GetClassID(out Guid classID)
        {
            classID = new Guid("E3480923-3A6C-41D2-B8D7-3B8D43D22530");
        }

        public void InitNew() { }

        public void Load(IPropertyBag propertyBag, int errorLog)
        {
            object val = ReadPropertyBag(propertyBag, "NewFileName");
            if (val != null)
            {
                NewFileName = (string)val;
            }
        }

        public void Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties)
        {
            WritePropertyBag(propertyBag, "NewFileName", NewFileName);
        }   

        private object ReadPropertyBag(IPropertyBag pb, string propName)
        {
            object value = null;
            try
            {
                pb.Read(propName, out value, 0);
            }
            catch (ArgumentException)
            {
                return value;
            }

            return value;
        }

        private void WritePropertyBag(IPropertyBag pb, string propName, object val)
        {
            pb.Write(propName, val);
        }
    }
}
