namespace WarehouseInventory.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WarehouseInventory.Models.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<WarehouseInventory.Models.Entities.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WarehouseInventory.Models.Entities.ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new List<CategoryEntity> {
                    new CategoryEntity {
                        Id = 1,
                        Name = "Vitamins & Supplements",
                        Description = "We are passionate about delivering scientifically supported vitamins and supplements to assist in maintaining optimal health and wellbeing. "
                        },
                    new CategoryEntity {
                        Id = 2,
                        Name = "Beauty & Personal Care",
                         Description = "We provide a comprehensive range of services for beauty and personal care products to ensure quality, safety, efficacy and regulatory compliance."
                    },
                    new CategoryEntity {
                        Id = 3,
                        Name = "Herbs & Botanicals",
                         Description = " We offer a wide range of herbs and botanicals for your at home herbal apothecary and herbal needs."
                    },
                    new CategoryEntity {
                        Id = 4,
                        Name = "Sports & Fitness",
                        Description = "Multi sports courts & fitness products are designed to get you active and having fun!"
                    }
                });
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new List<ProductEntity>
                    {
                        new ProductEntity
                        {
                            Id = 1,
                            Name = "Fusion Health Curcumin Advanced 60 Capsules",
                            Description = "A wonderful Curcumin from Turmeric can assist in inflammatory conditions.",
                            CategoryId = 1,
                            
                            Quantity = 25
                        },
                        new ProductEntity
                        {
                            Id = 2,
                            Name = "Blackmores Natural Vitamin E Cream 50G",
                            Description = "A rich moisturising cream to nourish and protect your skin.",
                            CategoryId = 2,
                         
                            Quantity = 20
                        },
                        new ProductEntity
                        {
                            Id = 3,
                            Name = "Nutralife Korean Ginseng 2500 50C",
                            Description = "Peak Performance Formula. Supports stamina, endurance & vitality.",
                            CategoryId = 3,

                            Quantity = 50
                        },
                        new ProductEntity
                        {
                            Id = 4,
                            Name = "Body Ripped Beta Alanine 100G",
                            Description = "ability to increase muscle carnosine levels",
                            CategoryId = 4,

                            Quantity = 40
                        }
                    }
                );
            }
        }
    }
}
