﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoffeeNation.Data.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ExceptionMessageResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionMessageResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CoffeeNation.Data.Resources.ExceptionMessageResources", typeof(ExceptionMessageResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The number of tokens in CSV line is incorrect (should be 3).
        /// </summary>
        internal static string IncorrectNumberOfTokensCsvLineExceptionMessage {
            get {
                return ResourceManager.GetString("IncorrectNumberOfTokensCsvLineExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value expected on CSV line position 1 (coffee shop name) is incorrect.
        /// </summary>
        internal static string IncorrectValuePosition1CsvLineExceptionMessage {
            get {
                return ResourceManager.GetString("IncorrectValuePosition1CsvLineExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value expected on CSV line position 2 (coffee shop coordinate X) is incorrect.
        /// </summary>
        internal static string IncorrectValuePosition2CsvLineExceptionMessage {
            get {
                return ResourceManager.GetString("IncorrectValuePosition2CsvLineExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value expected on CSV line position 3 (coffee shop coordinate Y) is incorrect.
        /// </summary>
        internal static string IncorrectValuePosition3CsvLineExceptionMessage {
            get {
                return ResourceManager.GetString("IncorrectValuePosition3CsvLineExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CSV line is null or empty.
        /// </summary>
        internal static string NullOrEmptyCsvLineExceptionMessage {
            get {
                return ResourceManager.GetString("NullOrEmptyCsvLineExceptionMessage", resourceCulture);
            }
        }
    }
}
