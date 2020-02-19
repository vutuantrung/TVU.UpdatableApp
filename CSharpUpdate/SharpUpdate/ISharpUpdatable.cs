using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

namespace SharpUpdate
{
    /// <summary>
    /// The interface that all applications need to implement in order to use SharpUpdate
    /// </summary>
    public interface ISharpUpdatable
    {
        /// <summary>
        /// The name of your application as you want it displayed on the update form
        /// </summary>
        string ApplicationName { get; }

        /// <summary>
        /// An identifier string to use to identify your application in the update.xml
        /// Should be the same as your appId in the update.xml
        /// </summary>
        string ApplicationID { get; }

        /// <summary>
        /// The current assembly
        /// </summary>
        Assembly ApplicationAssembly { get; }

        /// <summary>
        /// The location of the update.xml on a server
        /// </summary>
        Uri UpdateXmlApplication { get; }

        /// <summary>
        /// The context of the program.
        /// For Windows Form Application, use 'this'
        /// Console Apps, reference System.Windows.Forms and return null
        /// </summary>
        Form Context { get; }
    }
}
