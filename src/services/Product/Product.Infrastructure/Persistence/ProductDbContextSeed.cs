using Product.Domain.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Infrastructure.Persistence
{
    public class ProductDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ProductDbContext context)
        {
            // Seed, if necessary
            await SeedCategories(context);
            await SeedProducts(context);
        }


        private static async Task SeedProducts(ProductDbContext context)
        {
            if (!context.Products.Any())
            {

                await context.Products.AddRangeAsync(
                    new Domain.Entity.Product("BREAST (B/L)", 100.00m, 1, "MEAT", "CHICKEN", ""),
                    new Domain.Entity.Product("THIGH (B/L)", 100.00m, 1, "MEAT", "CHICKEN", ""),
                    new Domain.Entity.Product("WING (CUT) ", 100.00m, 1, "MEAT", "CHICKEN", ""),
                    new Domain.Entity.Product("EGG (X-L)", 100.00m, 5, "MEAT", "CHICKEN", ""),
                    new Domain.Entity.Product("RIB EYE (#2)", 100.00m, 5, "MEAT", "BEEF", ""),
                    new Domain.Entity.Product("SALMON (F)", 100.00m, 7, "MEAT", "FISH", ""),
                    new Domain.Entity.Product("SWAI", 100.00m, 0, "MEAT", "FISH", ""),
                    new Domain.Entity.Product("RICE", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("LOMAIN NOODLE #30", 100.00m, 2, "PRODUCE", "", ""),
                    new Domain.Entity.Product("EGG ROLL (CH)", 100.00m, 4, "PRODUCE", "", ""),
                    new Domain.Entity.Product("DUMPLING (KO)", 100.00m, 2, "PRODUCE", "", ""),
                    new Domain.Entity.Product("SUGAR", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("COOKING WINE", 100.00m, 2, "PRODUCE", "", ""),
                    new Domain.Entity.Product("MAYONNAISE", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("OIL", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("SOY SAUCE (5GL)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("TOFU (L)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("TOFU (S)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("SOY BEAN SPROUTS", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("B/ SPROUTS", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("ALFALFA", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("ASPARAGUS", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("BASIL", 100.00m, 1, "GROCERY", "", ""),
                    new Domain.Entity.Product("BROCCOLI (CUT)", 100.00m, 1, "GROCERY", "", ""),
                    new Domain.Entity.Product("COLLARD GREEN", 100.00m, 0, "GROCERY", "", ""),
                    new Domain.Entity.Product("CABBAGE (BOX)", 100.00m, 1, "GROCERY", "", ""),
                    new Domain.Entity.Product("CABBAGE (BAG)", 100.00m, 0, "GROCERY", "", ""),
                    new Domain.Entity.Product("CARROT", 100.00m, 5, "GROCERY", "", ""),
                    new Domain.Entity.Product("CAULIFLOWER", 100.00m, 6, "GROCERY", "", ""),
                    new Domain.Entity.Product("CELERY", 100.00m, 7, "GROCERY", "", ""),
                    new Domain.Entity.Product("CUCUMBER (KO)", 100.00m, 1, "GROCERY", "", ""),
                    new Domain.Entity.Product("GREEN LEAF", 100.00m, 15, "GROCERY", "", ""),
                    new Domain.Entity.Product("GREEN ONION", 100.00m, 1, "GROCERY", "", ""),
                    new Domain.Entity.Product("LETTUCE", 100.00m, 1, "GROCERY", "", ""),
                    new Domain.Entity.Product("MUSHROOM (LOOSE)", 100.00m, 8, "GROCERY", "", ""),
                    new Domain.Entity.Product("ONION (JUMBO)", 100.00m, 1, "GROCERY", "", ""),
                    new Domain.Entity.Product("POTATO", 100.00m, 1, "GROCERY", "", ""),
                    new Domain.Entity.Product("PEPPER (GREEN)", 100.00m, 2, "GROCERY", "", ""),
                    new Domain.Entity.Product("PEPPER (RED)", 100.00m, 7, "GROCERY", "", ""),
                    new Domain.Entity.Product("PEPPER (YELLOW)", 100.00m, 1, "GROCERY", "", ""),
                    new Domain.Entity.Product("ROMAIN", 100.00m, 1, "GROCERY", "", ""),
                    new Domain.Entity.Product("SQUASH (GREEN)", 100.00m, 8, "GROCERY", "", ""),
                    new Domain.Entity.Product("SPRING MIX", 100.00m, 0, "GROCERY", "", ""),
                    new Domain.Entity.Product("SPINACH (BUNCH)", 100.00m, 2, "GROCERY", "", ""),
                    new Domain.Entity.Product("ST - BEAN", 100.00m, 0, "GROCERY", "", ""),
                    new Domain.Entity.Product("TOMATO", 100.00m, 1, "GROCERY", "", ""),
                    new Domain.Entity.Product("TOMATO (PLUM)", 100.00m, 0, "GROCERY", "", ""),
                    new Domain.Entity.Product("WATER CRESS", 100.00m, 0, "GROCERY", "", ""),
                    new Domain.Entity.Product("YAM", 100.00m, 0, "GROCERY", "", ""),
                    new Domain.Entity.Product("APPLE (GREEN)", 100.00m, 1, "FRUIT", "", ""),
                    new Domain.Entity.Product("AVOCADO", 100.00m, 0, "FRUIT", "", ""),
                    new Domain.Entity.Product("BANANA", 100.00m, 1, "FRUIT", "", ""),
                    new Domain.Entity.Product("CANTALOUP", 100.00m, 1, "FRUIT", "", ""),
                    new Domain.Entity.Product("GRAPE (RED)", 100.00m, 1, "FRUIT", "", ""),
                    new Domain.Entity.Product("GRAPE (GREEN)", 100.00m, 2, "FRUIT", "", ""),
                    new Domain.Entity.Product("HONEYDEW", 100.00m, 0, "FRUIT", "", ""),
                    new Domain.Entity.Product("LEMON", 100.00m, 2, "FRUIT", "", ""),
                    new Domain.Entity.Product("MANGO", 100.00m, 2, "FRUIT", "", ""),
                    new Domain.Entity.Product("ORANGE", 100.00m, 1, "FRUIT", "", ""),
                    new Domain.Entity.Product("PINEAPPLE", 100.00m, 0, "FRUIT", "", ""),
                    new Domain.Entity.Product("STRAWBERRY", 100.00m, 0, "FRUIT", "", ""),
                    new Domain.Entity.Product("WATER MELON", 100.00m, 2, "FRUIT", "", ""),
                    new Domain.Entity.Product("KIWI", 100.00m, 2, "FRUIT", "", ""),
                    new Domain.Entity.Product("CHICKEN LIVER", 100.00m, 2, "MEAT", "CHICKEN", ""),
                    new Domain.Entity.Product("THIGH (B/IN)", 100.00m, 5, "MEAT", "CHICKEN", ""),
                    new Domain.Entity.Product("CHICKEN (WHOLE)", 100.00m, 9, "MEAT", "CHICKEN", ""),
                    new Domain.Entity.Product("MILK", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("BREADED SCALLOPE", 100.00m, 5, "FROZEN", "", ""),
                    new Domain.Entity.Product("MARGARINE", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("SAUSAGE", 100.00m, 6, "MEAT", "BEEF", ""),
                    new Domain.Entity.Product("PEA & CARROT", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("F/ CORN", 100.00m, 1, "PRODUCE", "", ""),
                    new Domain.Entity.Product("SHRIMP (61-70)", 100.00m, 1, "FROZEN", "", ""),
                    new Domain.Entity.Product("OLIVE OIL", 100.00m, 1, "PRODUCE", "", ""),
                    new Domain.Entity.Product("ROASTED PEANUT", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("MUSELL (L)", 100.00m, 4, "FROZEN", "", ""),
                    new Domain.Entity.Product("BALSAMIC V", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("CORN STARCH", 100.00m, 40, "PRODUCE", "", ""),
                    new Domain.Entity.Product("NOODLE (THAI)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("CHILI PASTE (KOCHUJANG)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("SALT", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("FLOUR 4LB", 100.00m, 1, "PRODUCE", "", ""),
                    new Domain.Entity.Product("KANARI SAUCE (KO)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("BABY ARUGULA", 100.00m, 4, "PRODUCE", "", ""),
                    new Domain.Entity.Product("CABBAGE (RED)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("CUCUMBER (AM)", 100.00m, 2, "PRODUCE", "", ""),
                    new Domain.Entity.Product("CUCUMBER (EU)", 100.00m, 1, "PRODUCE", "", ""),
                    new Domain.Entity.Product("KALE", 100.00m, 2, "PRODUCE", "", ""),
                    new Domain.Entity.Product("ONION (RED)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("POTATO (RED)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("PASLEY (CH)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("PASLEY (AM)", 100.00m, 1, "PRODUCE", "", ""),
                    new Domain.Entity.Product("SQUASH (YELLOW)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("SPINACH (BAG)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("EGG PLANT (CH)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("TOMATO (CH)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("JALAPINO PEPPER", 100.00m, 2, "PRODUCE", "", ""),
                    new Domain.Entity.Product("GINGER", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("APPLE (RED)", 100.00m, 0, "FRUIT", "", ""),
                    new Domain.Entity.Product("PLANTAIN", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("GRAPE FRUIT", 100.00m, 2, "FRUIT", "", ""),
                    new Domain.Entity.Product("RADISH (KO)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("CHERRY CTL", 100.00m, 5, "FRUIT", "", ""),
                    new Domain.Entity.Product("TUFU (SILK)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("GARLIC (POWDER)", 100.00m, 2, "PRODUCE", "", ""),
                    new Domain.Entity.Product("TOMATO (COLOR)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("GARLIC (FRESH)", 100.00m, 1, "PRODUCE", "", ""),
                    new Domain.Entity.Product("OYSTER (F/)", 100.00m, 1, "PRODUCE", "", ""),
                    new Domain.Entity.Product("ROACH SPRAY", 100.00m, 0, "ETC", "", ""),
                    new Domain.Entity.Product("RIB EYE (#3)", 100.00m, 10, "MEAT", "BEEF", ""),
                    new Domain.Entity.Product("LEG (1/4)", 100.00m, 1, "MEAT", "CHICKEN", ""),
                    new Domain.Entity.Product("BREAST (B/IN)", 100.00m, 1, "MEAT", "CHICKEN", ""),
                    new Domain.Entity.Product("BEEF (GROUND)", 100.00m, 15, "MEAT", "BEEF", ""),
                    new Domain.Entity.Product("MAGARINE", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("HONDASHI", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("VIGENAR", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("OAT MEAL", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("WINE (W)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("SNOW PEA", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("MUSTARD (PK)", 100.00m, 0, "PRODUCE", "", ""),
                    new Domain.Entity.Product("PL BAG (L)", 100.00m, 0, "PRODUCE", "", ""));
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedCategories(ProductDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(new Category("MEAT", ""),
                    new Category("FROZEN", ""),
                    new Category("PRODUCE", ""),
                    new Category("GROCERY", ""),
                    new Category("ETC", ""),
                    new Category("MEAT", "BEEF"),
                    new Category("MEAT", "CHICKEN"),
                    new Category("MEAT", "FISH"),
                    new Category("PRODUCE", "VEGETABLE"),
                    new Category("FRUIT", ""));

                await context.SaveChangesAsync();
            }
        }
    }
}