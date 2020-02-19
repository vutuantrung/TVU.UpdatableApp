using System;
using System.Net;
using System.Xml;

namespace CustomLibrary
{
    internal class SharpUpdateXml
    {
        private Version version;
        private Uri uri;
        private string fileName;
        private string md5;
        private string description;
        private string launchArgs;

        internal Version Version
        {
            get { return this.version; }
        }

        internal Uri Uri
        {
            get { return this.uri; }
        }

        internal string FileName
        {
            get { return this.fileName; }
        }

        internal string MD5
        {
            get { return this.md5; }
        }

        internal string Description
        {
            get { return this.description; }
        }

        internal string LauchArgs
        {
            get { return this.launchArgs; }
        }

        internal SharpUpdateXml(Version version, Uri uri, string fileName, string md5, string description, string launchArgs)
        {
            this.version = version;
            this.uri = uri;
            this.fileName = fileName;
            this.md5 = md5;
            this.description = description;
            this.launchArgs = launchArgs;
        }

        internal bool IsNewerThan(Version version)
        {
            return this.version > version;
        }

        internal static bool ExistsOnServer(Uri location)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(location.AbsoluteUri);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                res.Close();

                return res.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal static SharpUpdateXml Parse(Uri location, string appID)
        {
            Version version = null;
            string url = string.Empty, fileName = string.Empty, md5 = string.Empty, description = string.Empty, launchArgs = string.Empty;

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(location.AbsoluteUri);

                // Find the node update with the specific attribut appID
                XmlNode node = doc.DocumentElement.SelectSingleNode($"//update[@appID='{appID}'");

                if (node == null) return null;

                version = Version.Parse(node["lastestVersion"].InnerText);
                url = node["lastestVersionUrl"].InnerText;
                fileName = node["fileName"].InnerText;
                description = node["description"].InnerText;
                launchArgs = node["launchArgs"].InnerText;

                return new SharpUpdateXml(version, new Uri(url), fileName, md5, description, launchArgs);
            }
            catch
            {
                return null;
            }
        }
    }
}
