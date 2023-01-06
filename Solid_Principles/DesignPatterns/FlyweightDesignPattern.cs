using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Flyweight is to reuse
    // This is an Optimization Pattern - to reduce the Number of Instances
    // We reduce the objects that we create in memory, and objects which we create are flyweight
    // When you have an Icon and you want to reuse that in all Pages, then it will have duplicate Memory for all - This can be avoided

    // The Main Intent of this is to reuse/ Sharing to support large number of fine grained objects efficiently.
    // Mainly its used in Client side application - Mobile and Web Based Applications.

    // If you want to create objects for 5- 10 times then this is overkill to use this pattern.
    // Suppose you are creating 100's of same objects then it will be useful

    internal class FlyweightDesignPattern
    {
        // Example 1
        // Static Resource
        // Here this is Flyweight Object
        public class Icon
        {
            public string Color { get; set; }
            public Icon(string type)
            {

            }
        }

        
        public abstract class Button
        {
            public Icon Icon { get; set; }
        }


        // Flyweight Factory
        // We need to cache and reuse flyweight object
        public static class IconProvider
        {
            private static Dictionary<string, Icon> cache = new Dictionary<string, Icon>();
            public static Icon GetIcon(string type)
            {
                if(!cache.ContainsKey(type))
                {
                    cache[type] = new Icon(type);
                }
                return cache[type];
            }
        }

        // Intrinsic State
        // Extrinsic State

        public class SettingsButton : Button
        {

            public SettingsButton()
            {
                // This is where we need to load the icon from
                Icon = IconProvider.GetIcon("Settings");
            }
        }

        public class ClientFDP
        {
            public void Main()
            {
                // Users Page
                SettingsButton homeButton1 = new SettingsButton();

                // Audits Page
                SettingsButton homeButton2 = new SettingsButton();

                // Advanced Page
                SettingsButton homeButton3 = new SettingsButton();

                // Devices Page
                SettingsButton homeButton4 = new SettingsButton();
            }
        }



        // Example 2 
        public abstract class ButtonAbstract : Button
        {
            public abstract void ColorChange(string color);
        }

        public class SettingButton : ButtonAbstract
        {

            public SettingButton()
            {
                // Intrinsic State will be same
                // This is where we need to load the icon from
                Icon = IconProvider.GetIcon("Settings");
            }

            // Extrinsic State may differ - This is passed at Runtime - We can reuse
            public override void ColorChange(string color)
            {
                Icon.Color = color;
            }
        }

        // Even if you create 10 Time you will get Same Object, External State may differ at runtime
        // Dont change the Internal State. it will create side effects . it may behave differently for other components - this wont be flyweight
        public class UsersPage
        {
            public void Main()
            {
                SettingButton homeButton = new SettingButton();
                homeButton.ColorChange("Red");
            }

        }

        public class CredentialsPage
        {
            public void Main()
            {
                SettingButton homeButton = new SettingButton();
                homeButton.ColorChange("Blue");
            }
        }

        public class AuditsPage
        {
            public void Main()
            {
                SettingButton homeButton = new SettingButton();
                homeButton.ColorChange("Green");
            }
        }


    }
}
