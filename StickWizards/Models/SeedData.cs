using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StickWizards.Data;
using System;
using System.Linq;

namespace StickWizards.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StickWizardsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<StickWizardsContext>>()))
            {
                // Look for any sticks.
                if (context.Stick.Any())
                {
                    return;   // DB has been seeded
                }

                context.Stick.AddRange(
                    new Stick
                    {
                        Id=1,
                        Length = 7,
                        Material ="Wood",
                        Texture="Smooth",
                        Weight="2kg"
     
                    },

                    new Stick
                    {
                        Id = 2,
                        Length = 8,
                        
                        Material = "Tough Wood",
                        Texture = "Rough",
                        Weight = "2kg"
                    },

                    new Stick
                    {
                        Id = 3,
                        Length =5,
                        
                        Material = "Rubber",
                        Texture = "Smooth",
                        Weight = "1kg"
                    },

                    new Stick
                    {
                        Id = 4,
                        Length = 6,
                       
                        Material = "Bamboo",
                        Texture = "Rough",
                        Weight = "2kg"
                    },
                    new Stick
                    {
                        Id = 5,
                        Length = 4,
                        
                        Material = "Oak",
                        Texture = "Smooth",
                        Weight = "0.8kg"
                    },

                      new Stick
                      {
                        Id = 6,
                         Length = 4,
                        
                        Material = "Composite",
                        Texture = "Glossy",
                        Weight = "0.5kg"
                       },
                      new Stick
                      {
                          Id = 7,
                          Length = 6,
                          
                          Material = "Aluminum",
                          Texture = "Smooth",
                          Weight = "3kg"
                      },
                      new Stick
                      {
                          Id = 8,
                          Length = 6,
                          
                          Material = "Aluminum",
                          Texture = "Ribbed",
                          Weight = "0.7kg"
                      },
                      new Stick
                      {
                          Id = 9,
                          Length =8,
                          
                          Material = "Plastic",
                          Texture = "Textured",
                          Weight = "0.9kg"
                      },
                      new Stick
                      {
                          Id = 10,
                          Length = 9,
                          
                          Material = "Wood",
                          Texture = "Rough",
                          Weight = "0.4kg"
                      }



                );
                context.SaveChanges();
            }
        }
    }
}