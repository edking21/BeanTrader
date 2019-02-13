﻿using Castle.Windsor;
using Castle.Windsor.Installer;

namespace BeanTraderClient.DependencyInjection
{
    public class Bootstrapper
    {
        private static IWindsorContainer container;
        private static object syncRoot = new object();

        public static IWindsorContainer Container
        {
            get
            {
                if (container == null)
                {
                    lock (syncRoot)
                    {
                        if (container == null)
                        {
                            container = new WindsorContainer().Install(FromAssembly.This());
                        }
                    }
                }

                return container;
            }
        }
    }
}
