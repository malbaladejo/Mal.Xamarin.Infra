using Newtonsoft.Json;

namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Impl.Dtos
{

    internal class Product
    {
        [JsonProperty("nutrition_score_debug")]
        public string NutritionScoreDebug { get; set; }

        [JsonProperty("emb_code")]
        public string EmbCode { get; set; }

        [JsonProperty("nutrition_grades_tags")]
        public string[] NutritionGradesTags { get; set; }

        [JsonProperty("categories_hierarchy")]
        public string[] CategoriesHierarchy { get; set; }

        [JsonProperty("additives_prev")]
        public string AdditivesPrev { get; set; }

        [JsonProperty("checkers_tags")]
        public object[] CheckersTags { get; set; }

        [JsonProperty("categories")]
        public string Categories { get; set; }

        [JsonProperty("photographers_tags")]
        public string[] PhotographersTags { get; set; }

        [JsonProperty("vitamins_prev_tags")]
        public object[] VitaminsPrevTags { get; set; }

        [JsonProperty("image_ingredients_url")]
        public string ImageIngredientsUrl { get; set; }

        [JsonProperty("image_nutrition_small_url")]
        public string ImageNutritionSmallUrl { get; set; }

        [JsonProperty("nutrition_data_per")]
        public string NutritionDataPer { get; set; }

        [JsonProperty("max_imgid")]
        public string MaxImgid { get; set; }

        [JsonProperty("countries_tags")]
        public string[] CountriesTags { get; set; }

        [JsonProperty("nutriments")]
        public Nutriments Nutriments { get; set; }

        [JsonProperty("ingredients_debug")]
        public string[] IngredientsDebug { get; set; }

        [JsonProperty("image_ingredients_small_url")]
        public string ImageIngredientsSmallUrl { get; set; }

        [JsonProperty("image_small_url")]
        public string ImageSmallUrl { get; set; }

        [JsonProperty("emb_codes_tags")]
        public object[] EmbCodesTags { get; set; }

        [JsonProperty("categories_prev_hierarchy")]
        public string[] CategoriesPrevHierarchy { get; set; }

        [JsonProperty("product_name")]
        public string ProductName { get; set; }

        [JsonProperty("fruits-vegetables-nuts_100g_estimate")]
        public long FruitsVegetablesNuts100GEstimate { get; set; }

        [JsonProperty("cities_tags")]
        public object[] CitiesTags { get; set; }

        [JsonProperty("creator")]
        public string Creator { get; set; }

        [JsonProperty("pnns_groups_2_tags")]
        public string[] PnnsGroups2_Tags { get; set; }

        [JsonProperty("languages")]
        public Languages Languages { get; set; }

        [JsonProperty("emb_codes_20141016")]
        public string EmbCodes20141016 { get; set; }

        [JsonProperty("image_nutrition_thumb_url")]
        public string ImageNutritionThumbUrl { get; set; }

        [JsonProperty("informers_tags")]
        public string[] InformersTags { get; set; }

        [JsonProperty("serving_quantity")]
        public double ServingQuantity { get; set; }

        [JsonProperty("additives_original_tags")]
        public string[] AdditivesOriginalTags { get; set; }

        [JsonProperty("additives_prev_tags")]
        public object[] AdditivesPrevTags { get; set; }

        [JsonProperty("entry_dates_tags")]
        public string[] EntryDatesTags { get; set; }

        [JsonProperty("ingredients_n_tags")]
        public string[] IngredientsNTags { get; set; }

        [JsonProperty("nucleotides_tags")]
        public object[] NucleotidesTags { get; set; }

        [JsonProperty("image_ingredients_thumb_url")]
        public string ImageIngredientsThumbUrl { get; set; }

        [JsonProperty("labels_prev_hierarchy")]
        public string[] LabelsPrevHierarchy { get; set; }

        [JsonProperty("sortkey")]
        public long Sortkey { get; set; }

        [JsonProperty("editors")]
        public string[] Editors { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("completed_t")]
        public long CompletedT { get; set; }

        [JsonProperty("last_modified_t")]
        public long LastModifiedT { get; set; }

        [JsonProperty("ingredients")]
        public Ingredient[] Ingredients { get; set; }

        [JsonProperty("ingredients_text_with_allergens_fr")]
        public string IngredientsTextWithAllergensFr { get; set; }

        [JsonProperty("emb_codes_orig")]
        public string EmbCodesOrig { get; set; }

        [JsonProperty("states_tags")]
        public string[] StatesTags { get; set; }

        [JsonProperty("unknown_ingredients_n")]
        public long UnknownIngredientsN { get; set; }

        [JsonProperty("expiration_date")]
        public string ExpirationDate { get; set; }

        [JsonProperty("manufacturing_places_tags")]
        public string[] ManufacturingPlacesTags { get; set; }

        [JsonProperty("origins")]
        public string Origins { get; set; }

        [JsonProperty("additives_prev_original_tags")]
        public object[] AdditivesPrevOriginalTags { get; set; }

        [JsonProperty("photographers")]
        public string[] Photographers { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("vitamins_tags")]
        public object[] VitaminsTags { get; set; }

        [JsonProperty("languages_hierarchy")]
        public string[] LanguagesHierarchy { get; set; }

        [JsonProperty("last_edit_dates_tags")]
        public string[] LastEditDatesTags { get; set; }

        [JsonProperty("packaging")]
        public string Packaging { get; set; }

        [JsonProperty("serving_size")]
        public string ServingSize { get; set; }

        [JsonProperty("codes_tags")]
        public string[] CodesTags { get; set; }

        [JsonProperty("purchase_places")]
        public string PurchasePlaces { get; set; }

        [JsonProperty("traces_tags")]
        public string[] TracesTags { get; set; }

        [JsonProperty("origins_tags")]
        public string[] OriginsTags { get; set; }

        [JsonProperty("nutrition_grades")]
        public string NutritionGrades { get; set; }

        [JsonProperty("nutrient_levels_tags")]
        public string[] NutrientLevelsTags { get; set; }

        [JsonProperty("categories_tags")]
        public string[] CategoriesTags { get; set; }

        [JsonProperty("nucleotides_prev_tags")]
        public object[] NucleotidesPrevTags { get; set; }

        [JsonProperty("additives_debug_tags")]
        public object[] AdditivesDebugTags { get; set; }

        [JsonProperty("image_nutrition_url")]
        public string ImageNutritionUrl { get; set; }

        [JsonProperty("languages_tags")]
        public string[] LanguagesTags { get; set; }

        [JsonProperty("amino_acids_tags")]
        public object[] AminoAcidsTags { get; set; }

        [JsonProperty("countries_hierarchy")]
        public string[] CountriesHierarchy { get; set; }

        [JsonProperty("generic_name_fr")]
        public string GenericNameFr { get; set; }

        [JsonProperty("categories_debug_tags")]
        public string[] CategoriesDebugTags { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("manufacturing_places")]
        public string ManufacturingPlaces { get; set; }

        [JsonProperty("labels")]
        public string Labels { get; set; }

        [JsonProperty("image_front_small_url")]
        public string ImageFrontSmallUrl { get; set; }

        [JsonProperty("minerals_prev_tags")]
        public object[] MineralsPrevTags { get; set; }

        [JsonProperty("allergens")]
        public string Allergens { get; set; }

        [JsonProperty("ingredients_ids_debug")]
        public string[] IngredientsIdsDebug { get; set; }

        [JsonProperty("ingredients_from_palm_oil_n")]
        public long IngredientsFromPalmOilN { get; set; }

        [JsonProperty("complete")]
        public long Complete { get; set; }

        [JsonProperty("ingredients_text_debug")]
        public string IngredientsTextDebug { get; set; }

        [JsonProperty("ingredients_from_palm_oil_tags")]
        public object[] IngredientsFromPalmOilTags { get; set; }

        [JsonProperty("additives_tags")]
        public object[] AdditivesTags { get; set; }

        [JsonProperty("misc_tags")]
        public string[] MiscTags { get; set; }

        [JsonProperty("labels_hierarchy")]
        public string[] LabelsHierarchy { get; set; }

        [JsonProperty("rev")]
        public long Rev { get; set; }

        [JsonProperty("labels_prev_tags")]
        public string[] LabelsPrevTags { get; set; }

        [JsonProperty("ingredients_text_with_allergens")]
        public string IngredientsTextWithAllergens { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("_keywords")]
        public string[] Keywords { get; set; }

        [JsonProperty("packaging_tags")]
        public string[] PackagingTags { get; set; }

        [JsonProperty("correctors")]
        public string[] Correctors { get; set; }

        [JsonProperty("ingredients_text")]
        public string IngredientsText { get; set; }

        [JsonProperty("amino_acids_prev_tags")]
        public object[] AminoAcidsPrevTags { get; set; }

        [JsonProperty("ingredients_that_may_be_from_palm_oil_tags")]
        public object[] IngredientsThatMayBeFromPalmOilTags { get; set; }

        [JsonProperty("stores")]
        public string Stores { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("id")]
        public string ProductId { get; set; }

        [JsonProperty("languages_codes")]
        public LanguagesCodes LanguagesCodes { get; set; }

        [JsonProperty("unique_scans_n")]
        public long UniqueScansN { get; set; }

        [JsonProperty("additives_prev_n")]
        public long AdditivesPrevN { get; set; }

        [JsonProperty("emb_codes")]
        public string EmbCodes { get; set; }

        [JsonProperty("pnns_groups_2")]
        public string PnnsGroups2 { get; set; }

        [JsonProperty("traces")]
        public string Traces { get; set; }

        [JsonProperty("additives_old_n")]
        public long AdditivesOldN { get; set; }

        [JsonProperty("informers")]
        public string[] Informers { get; set; }

        [JsonProperty("nutrient_levels")]
        public NutrientLevels NutrientLevels { get; set; }

        [JsonProperty("last_modified_by")]
        public string LastModifiedBy { get; set; }

        [JsonProperty("image_front_thumb_url")]
        public string ImageFrontThumbUrl { get; set; }

        [JsonProperty("interface_version_modified")]
        public string InterfaceVersionModified { get; set; }

        [JsonProperty("pnns_groups_1")]
        public string PnnsGroups1 { get; set; }

        [JsonProperty("allergens_hierarchy")]
        public string[] AllergensHierarchy { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("checkers")]
        public object[] Checkers { get; set; }

        [JsonProperty("ingredients_from_or_that_may_be_from_palm_oil_n")]
        public long IngredientsFromOrThatMayBeFromPalmOilN { get; set; }

        [JsonProperty("last_editor")]
        public string LastEditor { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("labels_debug_tags")]
        public string[] LabelsDebugTags { get; set; }

        [JsonProperty("ingredients_n")]
        public string IngredientsN { get; set; }

        [JsonProperty("new_additives_n")]
        public long NewAdditivesN { get; set; }

        [JsonProperty("countries")]
        public string Countries { get; set; }

        [JsonProperty("stores_tags")]
        public string[] StoresTags { get; set; }

        [JsonProperty("no_nutrition_data")]
        public object NoNutritionData { get; set; }

        [JsonProperty("allergens_tags")]
        public string[] AllergensTags { get; set; }

        [JsonProperty("quality_tags")]
        public string[] QualityTags { get; set; }

        [JsonProperty("update_key")]
        public string UpdateKey { get; set; }

        [JsonProperty("minerals_tags")]
        public object[] MineralsTags { get; set; }

        [JsonProperty("lc")]
        public string Lc { get; set; }

        [JsonProperty("additives_n")]
        public long AdditivesN { get; set; }

        [JsonProperty("brands")]
        public string Brands { get; set; }

        [JsonProperty("additives_old_tags")]
        public object[] AdditivesOldTags { get; set; }

        [JsonProperty("created_t")]
        public long CreatedT { get; set; }

        [JsonProperty("ingredients_tags")]
        public string[] IngredientsTags { get; set; }

        [JsonProperty("correctors_tags")]
        public string[] CorrectorsTags { get; set; }

        [JsonProperty("ingredients_hierarchy")]
        public string[] IngredientsHierarchy { get; set; }

        [JsonProperty("image_thumb_url")]
        public string ImageThumbUrl { get; set; }

        [JsonProperty("ingredients_text_fr")]
        public string IngredientsTextFr { get; set; }

        [JsonProperty("last_image_dates_tags")]
        public string[] LastImageDatesTags { get; set; }

        [JsonProperty("additives")]
        public string Additives { get; set; }

        [JsonProperty("states_hierarchy")]
        public string[] StatesHierarchy { get; set; }

        [JsonProperty("unknown_nutrients_tags")]
        public object[] UnknownNutrientsTags { get; set; }

        [JsonProperty("purchase_places_tags")]
        public string[] PurchasePlacesTags { get; set; }

        [JsonProperty("generic_name")]
        public string GenericName { get; set; }

        [JsonProperty("image_front_url")]
        public string ImageFrontUrl { get; set; }

        [JsonProperty("categories_prev_tags")]
        public string[] CategoriesPrevTags { get; set; }

        [JsonProperty("editors_tags")]
        public string[] EditorsTags { get; set; }

        [JsonProperty("selected_images")]
        public SelectedImages SelectedImages { get; set; }

        [JsonProperty("scans_n")]
        public long ScansN { get; set; }

        [JsonProperty("nutrition_score_warning_no_fruits_vegetables_nuts")]
        public long NutritionScoreWarningNoFruitsVegetablesNuts { get; set; }

        [JsonProperty("states")]
        public string States { get; set; }

        [JsonProperty("labels_tags")]
        public string[] LabelsTags { get; set; }

        [JsonProperty("nutrition_grade_fr")]
        public string NutritionGradeFr { get; set; }

        [JsonProperty("ingredients_that_may_be_from_palm_oil_n")]
        public long IngredientsThatMayBeFromPalmOilN { get; set; }

        [JsonProperty("pnns_groups_1_tags")]
        public string[] PnnsGroups1_Tags { get; set; }

        [JsonProperty("product_name_fr")]
        public string ProductNameFr { get; set; }

        [JsonProperty("brands_tags")]
        public string[] BrandsTags { get; set; }

        [JsonProperty("traces_hierarchy")]
        public string[] TracesHierarchy { get; set; }

        [JsonProperty("last_image_t")]
        public long LastImageT { get; set; }
    }
}
