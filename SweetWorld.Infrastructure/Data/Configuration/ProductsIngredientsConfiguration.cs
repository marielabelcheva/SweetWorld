using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Infrastructure.Data.Configuration
{
    public class ProductsIngredientsConfiguration : IEntityTypeConfiguration<ProductsIngredients>
    {
        public void Configure(EntityTypeBuilder<ProductsIngredients> builder)
        {
            builder.ToTable("products_ingredients");
            builder.HasKey(product => new { product.IngredientId, product.ProductId });
            builder.Property(product => product.ProductId).HasColumnName("product_id");
            builder.Property(product => product.IngredientId).HasColumnName("ingredient_id");

            builder.HasData(CreateProductsIngredients());
        }

        private List<ProductsIngredients> CreateProductsIngredients()
        {
            List<ProductsIngredients> productsIngredients = new List<ProductsIngredients>();

            productsIngredients.AddRange(new List<ProductsIngredients>()
            {
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("f5f626f4-9a54-48bc-8cda-e68926a4e628"),
                    IngredientId = Guid.Parse("85311af6-ce87-461c-b7ff-699a86eb0b47")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("f5f626f4-9a54-48bc-8cda-e68926a4e628"),
                    IngredientId = Guid.Parse("a95acbbb-6cef-4a7b-a245-7f8d028e0de7")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("f5f626f4-9a54-48bc-8cda-e68926a4e628"),
                    IngredientId = Guid.Parse("d62340b8-b340-4765-a289-cc4ec987e23a")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("f5f626f4-9a54-48bc-8cda-e68926a4e628"),
                    IngredientId = Guid.Parse("6a76316d-e003-40d4-8d5e-553d6c59747f")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("f5f626f4-9a54-48bc-8cda-e68926a4e628"),
                    IngredientId = Guid.Parse("beee5e53-e8ef-4d6e-a113-b449540d398e")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("f5f626f4-9a54-48bc-8cda-e68926a4e628"),
                    IngredientId = Guid.Parse("9216d028-f18e-44d4-b932-2f78719c0cba")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("f5f626f4-9a54-48bc-8cda-e68926a4e628"),
                    IngredientId = Guid.Parse("775e23ed-1fb6-4125-b23c-c43cb98fe1b6")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("f5f626f4-9a54-48bc-8cda-e68926a4e628"),
                    IngredientId = Guid.Parse("75879d97-4f7e-4f11-860d-205d63dfb1e9")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("f5f626f4-9a54-48bc-8cda-e68926a4e628"),
                    IngredientId = Guid.Parse("8e394b57-2c7a-42a1-b700-263d57f8cc5e")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("f5f626f4-9a54-48bc-8cda-e68926a4e628"),
                    IngredientId = Guid.Parse("e880c006-3af2-4d28-b8a4-7684cb986185")
                }
            });

            productsIngredients.AddRange(new List<ProductsIngredients>()
            {
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f"),
                    IngredientId = Guid.Parse("85311af6-ce87-461c-b7ff-699a86eb0b47")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f"),
                    IngredientId = Guid.Parse("a95acbbb-6cef-4a7b-a245-7f8d028e0de7")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f"),
                    IngredientId = Guid.Parse("d62340b8-b340-4765-a289-cc4ec987e23a")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f"),
                    IngredientId = Guid.Parse("6a76316d-e003-40d4-8d5e-553d6c59747f")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f"),
                    IngredientId = Guid.Parse("beee5e53-e8ef-4d6e-a113-b449540d398e")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f"),
                    IngredientId = Guid.Parse("9216d028-f18e-44d4-b932-2f78719c0cba")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f"),
                    IngredientId = Guid.Parse("ac441ba7-a0ff-4f44-84e8-3c11b8430c73")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f"),
                    IngredientId = Guid.Parse("75879d97-4f7e-4f11-860d-205d63dfb1e9")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f"),
                    IngredientId = Guid.Parse("16fe2f69-513c-4277-af3d-52b641fe9487")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f"),
                    IngredientId = Guid.Parse("662c546d-3e05-4cb4-a392-682cb3fed443")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("dea18594-de69-4d30-9acd-0f2af621d27f"),
                    IngredientId = Guid.Parse("cb3fc820-bf1d-4eee-a6c4-a9183618283a")
                }
            });

            productsIngredients.AddRange(new List<ProductsIngredients>()
            {
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102"),
                    IngredientId = Guid.Parse("85311af6-ce87-461c-b7ff-699a86eb0b47")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102"),
                    IngredientId = Guid.Parse("a95acbbb-6cef-4a7b-a245-7f8d028e0de7")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102"),
                    IngredientId = Guid.Parse("d62340b8-b340-4765-a289-cc4ec987e23a")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102"),
                    IngredientId = Guid.Parse("6a76316d-e003-40d4-8d5e-553d6c59747f")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102"),
                    IngredientId = Guid.Parse("beee5e53-e8ef-4d6e-a113-b449540d398e")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102"),
                    IngredientId = Guid.Parse("9216d028-f18e-44d4-b932-2f78719c0cba")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102"),
                    IngredientId = Guid.Parse("1776e340-9db2-453a-b29f-947b732796cc")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102"),
                    IngredientId = Guid.Parse("287e7803-b225-4131-b7f4-e3b57de672af")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102"),
                    IngredientId = Guid.Parse("75879d97-4f7e-4f11-860d-205d63dfb1e9")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102"),
                    IngredientId = Guid.Parse("ae5e95cb-f722-4460-8f07-29d58df97a55")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102"),
                    IngredientId = Guid.Parse("662c546d-3e05-4cb4-a392-682cb3fed443")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f2a35c9-e3f5-4361-b393-d9ac177c4102"),
                    IngredientId = Guid.Parse("cb3fc820-bf1d-4eee-a6c4-a9183618283a")
                }
            });

            productsIngredients.AddRange(new List<ProductsIngredients>()
            {
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b"),
                    IngredientId = Guid.Parse("85311af6-ce87-461c-b7ff-699a86eb0b47")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b"),
                    IngredientId = Guid.Parse("a95acbbb-6cef-4a7b-a245-7f8d028e0de7")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b"),
                    IngredientId = Guid.Parse("d62340b8-b340-4765-a289-cc4ec987e23a")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b"),
                    IngredientId = Guid.Parse("6a76316d-e003-40d4-8d5e-553d6c59747f")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b"),
                    IngredientId = Guid.Parse("beee5e53-e8ef-4d6e-a113-b449540d398e")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b"),
                    IngredientId = Guid.Parse("9216d028-f18e-44d4-b932-2f78719c0cba")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b"),
                    IngredientId = Guid.Parse("1776e340-9db2-453a-b29f-947b732796cc")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b"),
                    IngredientId = Guid.Parse("287e7803-b225-4131-b7f4-e3b57de672af")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b"),
                    IngredientId = Guid.Parse("75879d97-4f7e-4f11-860d-205d63dfb1e9")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b"),
                    IngredientId = Guid.Parse("ae5e95cb-f722-4460-8f07-29d58df97a55")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b"),
                    IngredientId = Guid.Parse("662c546d-3e05-4cb4-a392-682cb3fed443")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b"),
                    IngredientId = Guid.Parse("cb3fc820-bf1d-4eee-a6c4-a9183618283a")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4ccaf1dc-9bf9-4f55-beec-cd38bbb4701b"),
                    IngredientId = Guid.Parse("7d52d73e-b4e5-45f6-999e-9e7bd42e8a93")
                }
            });

            productsIngredients.AddRange(new List<ProductsIngredients>()
            {
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("5229ab70-1818-42be-b0c2-3b4da48a3caa"),
                    IngredientId = Guid.Parse("85311af6-ce87-461c-b7ff-699a86eb0b47")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("5229ab70-1818-42be-b0c2-3b4da48a3caa"),
                    IngredientId = Guid.Parse("a95acbbb-6cef-4a7b-a245-7f8d028e0de7")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("5229ab70-1818-42be-b0c2-3b4da48a3caa"),
                    IngredientId = Guid.Parse("6a76316d-e003-40d4-8d5e-553d6c59747f")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("5229ab70-1818-42be-b0c2-3b4da48a3caa"),
                    IngredientId = Guid.Parse("beee5e53-e8ef-4d6e-a113-b449540d398e")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("5229ab70-1818-42be-b0c2-3b4da48a3caa"),
                    IngredientId = Guid.Parse("75879d97-4f7e-4f11-860d-205d63dfb1e9")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("5229ab70-1818-42be-b0c2-3b4da48a3caa"),
                    IngredientId = Guid.Parse("c067592d-7db2-476b-8216-da94a089b269")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("5229ab70-1818-42be-b0c2-3b4da48a3caa"),
                    IngredientId = Guid.Parse("cb3fc820-bf1d-4eee-a6c4-a9183618283a")
                }
            });

            productsIngredients.AddRange(new List<ProductsIngredients>()
            {
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("defc5f08-42d7-495f-bd66-a762226d29c5"),
                    IngredientId = Guid.Parse("85311af6-ce87-461c-b7ff-699a86eb0b47")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("defc5f08-42d7-495f-bd66-a762226d29c5"),
                    IngredientId = Guid.Parse("a95acbbb-6cef-4a7b-a245-7f8d028e0de7")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("defc5f08-42d7-495f-bd66-a762226d29c5"),
                    IngredientId = Guid.Parse("6a76316d-e003-40d4-8d5e-553d6c59747f")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("defc5f08-42d7-495f-bd66-a762226d29c5"),
                    IngredientId = Guid.Parse("beee5e53-e8ef-4d6e-a113-b449540d398e")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("defc5f08-42d7-495f-bd66-a762226d29c5"),
                    IngredientId = Guid.Parse("75879d97-4f7e-4f11-860d-205d63dfb1e9")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("defc5f08-42d7-495f-bd66-a762226d29c5"),
                    IngredientId = Guid.Parse("9216d028-f18e-44d4-b932-2f78719c0cba")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("defc5f08-42d7-495f-bd66-a762226d29c5"),
                    IngredientId = Guid.Parse("cb3fc820-bf1d-4eee-a6c4-a9183618283a")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("defc5f08-42d7-495f-bd66-a762226d29c5"),
                    IngredientId = Guid.Parse("d62340b8-b340-4765-a289-cc4ec987e23a")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("defc5f08-42d7-495f-bd66-a762226d29c5"),
                    IngredientId = Guid.Parse("19c410e1-f574-4e2e-b235-51906d01c727")
                }
            });

            productsIngredients.AddRange(new List<ProductsIngredients>()
            {
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("64575b60-9c13-4f54-aee4-20dbf9d1f3cb"),
                    IngredientId = Guid.Parse("85311af6-ce87-461c-b7ff-699a86eb0b47")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("64575b60-9c13-4f54-aee4-20dbf9d1f3cb"),
                    IngredientId = Guid.Parse("a95acbbb-6cef-4a7b-a245-7f8d028e0de7")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("64575b60-9c13-4f54-aee4-20dbf9d1f3cb"),
                    IngredientId = Guid.Parse("6a76316d-e003-40d4-8d5e-553d6c59747f")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("64575b60-9c13-4f54-aee4-20dbf9d1f3cb"),
                    IngredientId = Guid.Parse("beee5e53-e8ef-4d6e-a113-b449540d398e")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("64575b60-9c13-4f54-aee4-20dbf9d1f3cb"),
                    IngredientId = Guid.Parse("ae5e95cb-f722-4460-8f07-29d58df97a55")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("64575b60-9c13-4f54-aee4-20dbf9d1f3cb"),
                    IngredientId = Guid.Parse("9216d028-f18e-44d4-b932-2f78719c0cba")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("64575b60-9c13-4f54-aee4-20dbf9d1f3cb"),
                    IngredientId = Guid.Parse("16fe2f69-513c-4277-af3d-52b641fe9487")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("64575b60-9c13-4f54-aee4-20dbf9d1f3cb"),
                    IngredientId = Guid.Parse("d62340b8-b340-4765-a289-cc4ec987e23a")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("64575b60-9c13-4f54-aee4-20dbf9d1f3cb"),
                    IngredientId = Guid.Parse("ac441ba7-a0ff-4f44-84e8-3c11b8430c73")
                }
            });

            productsIngredients.AddRange(new List<ProductsIngredients>()
            {
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2"),
                    IngredientId = Guid.Parse("85311af6-ce87-461c-b7ff-699a86eb0b47")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2"),
                    IngredientId = Guid.Parse("a95acbbb-6cef-4a7b-a245-7f8d028e0de7")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2"),
                    IngredientId = Guid.Parse("6a76316d-e003-40d4-8d5e-553d6c59747f")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2"),
                    IngredientId = Guid.Parse("beee5e53-e8ef-4d6e-a113-b449540d398e")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2"),
                    IngredientId = Guid.Parse("75879d97-4f7e-4f11-860d-205d63dfb1e9")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2"),
                    IngredientId = Guid.Parse("9216d028-f18e-44d4-b932-2f78719c0cba")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2"),
                    IngredientId = Guid.Parse("cb3fc820-bf1d-4eee-a6c4-a9183618283a")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2"),
                    IngredientId = Guid.Parse("d62340b8-b340-4765-a289-cc4ec987e23a")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2"),
                    IngredientId = Guid.Parse("19c410e1-f574-4e2e-b235-51906d01c727")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2"),
                    IngredientId = Guid.Parse("ae5e95cb-f722-4460-8f07-29d58df97a55")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2"),
                    IngredientId = Guid.Parse("16fe2f69-513c-4277-af3d-52b641fe9487")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2"),
                    IngredientId = Guid.Parse("ac441ba7-a0ff-4f44-84e8-3c11b8430c73")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("1824a2d5-1519-4173-b628-6ccee98019b2"),
                    IngredientId = Guid.Parse("5df10646-eaea-4040-b50c-393cf49ca75e")
                }
            });

            productsIngredients.AddRange(new List<ProductsIngredients>()
            {
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8d23fc0e-42c7-4a64-8100-63d6cf061421"),
                    IngredientId = Guid.Parse("701c2a97-48ac-4781-8a08-c60c6aa3f040")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8d23fc0e-42c7-4a64-8100-63d6cf061421"),
                    IngredientId = Guid.Parse("be3ebdea-a67c-4a28-b83e-c238cb85c09d")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8d23fc0e-42c7-4a64-8100-63d6cf061421"),
                    IngredientId = Guid.Parse("5f89b69f-ee79-488e-bd01-9527b101493a")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8d23fc0e-42c7-4a64-8100-63d6cf061421"),
                    IngredientId = Guid.Parse("e880c006-3af2-4d28-b8a4-7684cb986185")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8d23fc0e-42c7-4a64-8100-63d6cf061421"),
                    IngredientId = Guid.Parse("75879d97-4f7e-4f11-860d-205d63dfb1e9")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8d23fc0e-42c7-4a64-8100-63d6cf061421"),
                    IngredientId = Guid.Parse("9216d028-f18e-44d4-b932-2f78719c0cba")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8d23fc0e-42c7-4a64-8100-63d6cf061421"),
                    IngredientId = Guid.Parse("775e23ed-1fb6-4125-b23c-c43cb98fe1b6")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8d23fc0e-42c7-4a64-8100-63d6cf061421"),
                    IngredientId = Guid.Parse("6ad109c5-e8e7-4f40-8c0e-434f272db285")
                }
            });

            productsIngredients.AddRange(new List<ProductsIngredients>()
            {
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4b856ddb-c40f-404e-9b06-164ebb3755cf"),
                    IngredientId = Guid.Parse("85311af6-ce87-461c-b7ff-699a86eb0b47")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4b856ddb-c40f-404e-9b06-164ebb3755cf"),
                    IngredientId = Guid.Parse("a95acbbb-6cef-4a7b-a245-7f8d028e0de7")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4b856ddb-c40f-404e-9b06-164ebb3755cf"),
                    IngredientId = Guid.Parse("662c546d-3e05-4cb4-a392-682cb3fed443")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4b856ddb-c40f-404e-9b06-164ebb3755cf"),
                    IngredientId = Guid.Parse("6ad109c5-e8e7-4f40-8c0e-434f272db285")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4b856ddb-c40f-404e-9b06-164ebb3755cf"),
                    IngredientId = Guid.Parse("75879d97-4f7e-4f11-860d-205d63dfb1e9")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4b856ddb-c40f-404e-9b06-164ebb3755cf"),
                    IngredientId = Guid.Parse("9216d028-f18e-44d4-b932-2f78719c0cba")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4b856ddb-c40f-404e-9b06-164ebb3755cf"),
                    IngredientId = Guid.Parse("ae5e95cb-f722-4460-8f07-29d58df97a55")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4b856ddb-c40f-404e-9b06-164ebb3755cf"),
                    IngredientId = Guid.Parse("16fe2f69-513c-4277-af3d-52b641fe9487")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("4b856ddb-c40f-404e-9b06-164ebb3755cf"),
                    IngredientId = Guid.Parse("ac3d8343-895b-4805-aaeb-3b0d2f9de96a")
                }
            });

            productsIngredients.AddRange(new List<ProductsIngredients>()
            {
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("3b4feead-b9a6-41e4-b96a-42a50609603d"),
                    IngredientId = Guid.Parse("0955c74b-8e3c-4ad6-97fc-bdc72c4a70f2")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("3b4feead-b9a6-41e4-b96a-42a50609603d"),
                    IngredientId = Guid.Parse("ad8bddfd-a20d-4f5b-b53b-86e008dc3fc1")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("3b4feead-b9a6-41e4-b96a-42a50609603d"),
                    IngredientId = Guid.Parse("75879d97-4f7e-4f11-860d-205d63dfb1e9")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("3b4feead-b9a6-41e4-b96a-42a50609603d"),
                    IngredientId = Guid.Parse("9216d028-f18e-44d4-b932-2f78719c0cba")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("3b4feead-b9a6-41e4-b96a-42a50609603d"),
                    IngredientId = Guid.Parse("775e23ed-1fb6-4125-b23c-c43cb98fe1b6")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("3b4feead-b9a6-41e4-b96a-42a50609603d"),
                    IngredientId = Guid.Parse("ac441ba7-a0ff-4f44-84e8-3c11b8430c73")
                }
            });

            productsIngredients.AddRange(new List<ProductsIngredients>()
            {
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("e4dfb73d-8426-4c5e-bade-452c6d43bc3b"),
                    IngredientId = Guid.Parse("65009db2-6a67-470e-951b-b9dfd68109f8")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("e4dfb73d-8426-4c5e-bade-452c6d43bc3b"),
                    IngredientId = Guid.Parse("5a35c906-4373-43ef-a4c5-316058e22536")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("e4dfb73d-8426-4c5e-bade-452c6d43bc3b"),
                    IngredientId = Guid.Parse("beee5e53-e8ef-4d6e-a113-b449540d398e")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("e4dfb73d-8426-4c5e-bade-452c6d43bc3b"),
                    IngredientId = Guid.Parse("6a76316d-e003-40d4-8d5e-553d6c59747f")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("e4dfb73d-8426-4c5e-bade-452c6d43bc3b"),
                    IngredientId = Guid.Parse("9216d028-f18e-44d4-b932-2f78719c0cba")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("e4dfb73d-8426-4c5e-bade-452c6d43bc3b"),
                    IngredientId = Guid.Parse("ae5e95cb-f722-4460-8f07-29d58df97a55")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("e4dfb73d-8426-4c5e-bade-452c6d43bc3b"),
                    IngredientId = Guid.Parse("ac441ba7-a0ff-4f44-84e8-3c11b8430c73")
                }
            });

            productsIngredients.AddRange(new List<ProductsIngredients>()
            {
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f9967a1-2dd4-4d7e-9160-93da660a3d01"),
                    IngredientId = Guid.Parse("65009db2-6a67-470e-951b-b9dfd68109f8")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f9967a1-2dd4-4d7e-9160-93da660a3d01"),
                    IngredientId = Guid.Parse("26e2241b-5ef0-4998-bf81-3be8b5c5dd64")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f9967a1-2dd4-4d7e-9160-93da660a3d01"),
                    IngredientId = Guid.Parse("59a4a752-8e59-4cc9-a5f2-5b52f5e998ca")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f9967a1-2dd4-4d7e-9160-93da660a3d01"),
                    IngredientId = Guid.Parse("5a35c906-4373-43ef-a4c5-316058e22536")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f9967a1-2dd4-4d7e-9160-93da660a3d01"),
                    IngredientId = Guid.Parse("05810086-be70-48b4-a40c-0330ebea7f7e")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f9967a1-2dd4-4d7e-9160-93da660a3d01"),
                    IngredientId = Guid.Parse("6a76316d-e003-40d4-8d5e-553d6c59747f")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f9967a1-2dd4-4d7e-9160-93da660a3d01"),
                    IngredientId = Guid.Parse("9216d028-f18e-44d4-b932-2f78719c0cba")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f9967a1-2dd4-4d7e-9160-93da660a3d01"),
                    IngredientId = Guid.Parse("75879d97-4f7e-4f11-860d-205d63dfb1e9")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("8f9967a1-2dd4-4d7e-9160-93da660a3d01"),
                    IngredientId = Guid.Parse("d8acfa7d-2e90-4fc3-a2a0-89441d7866c2")
                }
            });

            productsIngredients.AddRange(new List<ProductsIngredients>()
            {
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("b21d0d2d-fe21-4080-8f99-d7b61574957f"),
                    IngredientId = Guid.Parse("25464223-7321-45e1-a377-e3d3bc9a1a70")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("b21d0d2d-fe21-4080-8f99-d7b61574957f"),
                    IngredientId = Guid.Parse("1c73c664-4242-467f-a13f-5816ed222b97")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("b21d0d2d-fe21-4080-8f99-d7b61574957f"),
                    IngredientId = Guid.Parse("2d8b869c-ef64-44d9-807a-1221ff08e3b9")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("b21d0d2d-fe21-4080-8f99-d7b61574957f"),
                    IngredientId = Guid.Parse("d90013c0-3372-4dce-8376-9d50e1952a0d")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("b21d0d2d-fe21-4080-8f99-d7b61574957f"),
                    IngredientId = Guid.Parse("662c546d-3e05-4cb4-a392-682cb3fed443")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("b21d0d2d-fe21-4080-8f99-d7b61574957f"),
                    IngredientId = Guid.Parse("6a76316d-e003-40d4-8d5e-553d6c59747f")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("b21d0d2d-fe21-4080-8f99-d7b61574957f"),
                    IngredientId = Guid.Parse("9216d028-f18e-44d4-b932-2f78719c0cba")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("b21d0d2d-fe21-4080-8f99-d7b61574957f"),
                    IngredientId = Guid.Parse("75879d97-4f7e-4f11-860d-205d63dfb1e9")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("b21d0d2d-fe21-4080-8f99-d7b61574957f"),
                    IngredientId = Guid.Parse("5f89b69f-ee79-488e-bd01-9527b101493a")
                },
                new ProductsIngredients()
                {
                    ProductId = Guid.Parse("b21d0d2d-fe21-4080-8f99-d7b61574957f"),
                    IngredientId = Guid.Parse("6ad109c5-e8e7-4f40-8c0e-434f272db285")
                }
            });

            return productsIngredients;
        }
    }
}
