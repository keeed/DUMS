using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using DUMS.Data.Contract.UserManagement.Objects;
using DUMS.Data.DataProviders.XMLDataProvider.Objects;

namespace DUMS.Data.DataProviders.XMLDataProvider.Utilities
{
    public class XMLHandler
    {
        #region Fields
        private XMLData _xmlData = new XMLData();
        #endregion

        #region Properties
        public XMLData XMLData
        {
            get
            {
                return _xmlData;
            }
            set
            {
                _xmlData = value;
            }
        }
        #endregion

        #region Methods

        public List<UserAccount> LoadUserAccountsFromXml(string connectionString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<UserAccount>));

            FileStream fs = new FileStream(connectionString, FileMode.Open);
            XmlReader xmlReader = XmlReader.Create(fs);

            List<UserAccount> _accounts;

            _accounts = (List<UserAccount>)xmlSerializer.Deserialize(xmlReader);

            fs.Close();

            return _accounts;
        }

        public void SaveXml(List<UserAccount> userAccount)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<UserAccount>));

            System.IO.StreamWriter file = new System.IO.StreamWriter(@"Data.xml");
            xmlSerializer.Serialize(file, userAccount);
            file.Close();
        }

        #endregion
    }
}
