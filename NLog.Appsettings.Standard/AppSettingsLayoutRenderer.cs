using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using NLog.Config;
using NLog.LayoutRenderers;

namespace NLog.Appsettings.Standard
{
    [LayoutRenderer("appsettings")]
    public class AppSettingsLayoutRenderer : LayoutRenderer
    {
        private static IConfigurationRoot _configurationRoot;

        ///<summary>
		/// The AppSetting name.
		///</summary>
		[RequiredParameter]
		[DefaultParameter]
		public string Name { get; set; }

		///<summary>
		/// The default value to render if the AppSetting value is null.
		///</summary>
		public string Default { get; set; }

		internal IConfigurationRoot Settings
		{
			get => _configurationRoot;
		    set => _configurationRoot = value;
		}

        public AppSettingsLayoutRenderer() {

            if(Settings == null)
			{
				Settings = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                			.AddJsonFile("appsettings.json")
                			.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true).Build();
			}
        }

        /// <summary>
		/// Renders the specified application setting or default value and appends it to the specified <see cref="StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="StringBuilder"/> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            if (Name == null)
				return;            

            string value = AppSettingValue;
			if (value == null && Default != null)
				value = Default;

            if (string.IsNullOrEmpty(value) == false)
				builder.Append(value);
        }

        private bool _cachedAppSettingValue = false;
		private string _appSettingValue = null;		
		private string AppSettingValue
		{
			get
			{
                Name = Name.Replace('.',':');
				if (_cachedAppSettingValue == false)
				{
					_appSettingValue = Settings[Name];
					_cachedAppSettingValue = true;
				}
				return _appSettingValue;
			}
		}
    }
}
