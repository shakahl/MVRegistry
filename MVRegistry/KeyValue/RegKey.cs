using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVRegistry.KeyValue
{
    internal class RegKey : IRegKey, IDisposable
    {
        RegistryKey reg;

        public void Create(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name is empty");

            if (Config.HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Config.Address, true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Config.Address, true);
            if (reg.OpenSubKey(name) == null)
            {
                reg.CreateSubKey(name);
            }
            reg.Close();
        }

        public void Delete(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name is empty");

            if (Config.HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Config.Address, true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Config.Address, true);
            if (reg.OpenSubKey(name) != null)
            {
                reg.DeleteSubKeyTree(name);
            }
            reg.Close();
        }

        public string[] GetNames()
        {
            if (Config.HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Config.Address, true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Config.Address, true);
            string[] reglist = reg.GetSubKeyNames();
            reg.Close();
            return reglist;
        }

        public bool Exists(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name is empty");

            if (Config.HKEY == HKEY.ClassesRoot)
                reg = Registry.ClassesRoot.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.CurrentUser)
                reg = Registry.CurrentUser.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.LocalMachine)
                reg = Registry.LocalMachine.OpenSubKey(Config.Address, true);
            else if (Config.HKEY == HKEY.Users)
                reg = Registry.Users.OpenSubKey(Config.Address, true);
            else
                reg = Registry.CurrentConfig.OpenSubKey(Config.Address, true);

            bool allow = false;
            string[] keys = reg.GetSubKeyNames();
            foreach (var i in keys)
            {
                if (i.Contains(name))
                {
                    allow = true;
                }
            }
            reg.Close();
            return allow;
        }

        public void Dispose()
        {
            reg.Close();
            reg.Dispose();
        }
    }
}
