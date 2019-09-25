using System.Xml.Linq;
using System.Xml.Schema;

namespace ApplicationRepository.XML
{

    internal static class SchemaValidatorExtensions
    {
        internal static bool ValidateDocument(this XDocument document, XmlSchemaSet schema)
        { 
            try
            {
                document.Validate(schema, null);
                return true;
            }
            catch (XmlSchemaValidationException ex)
            {
                throw ex;
            }
        }
    }
}
