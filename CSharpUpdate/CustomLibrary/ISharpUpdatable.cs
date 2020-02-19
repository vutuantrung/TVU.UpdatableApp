using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

namespace CustomLibrary
{
    public interface ISharpUpdatable
    {
        string ApplicationName { get; }
        string ApplicationID { get; }
        Assembly ApplicationAssembly { get; }
        Uri UpdateXmlApplication { get; }
        Form Context { get; }
    }
}
