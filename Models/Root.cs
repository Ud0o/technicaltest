using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustEatTechnicalTest.Models
{
    public class Root
    {
        public List<RestaurantSet> RestaurantSets { get; set; }
        public List<CuisineSet> CuisineSets { get; set; }
        public List<View> Views { get; set; }
        public List<Restaurant> Restaurants { get; set; }
        public string ShortResultText { get; set; }
        public string Area { get; set; }
        public List<object> Errors { get; set; }
        public bool HasErrors { get; set; }
        public MetaData2 MetaData { get; set; }
    }

    public class Metadata
    {
        public string Rating { get; set; }
    }

    public class RestaurantSmall
    {
        public int Id { get; set; }
        public Metadata Metadata { get; set; }
    }

    public class RestaurantSet
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<RestaurantSmall> Restaurants { get; set; }
    }

    public class Cuisine
    {
        public string Name { get; set; }
        public string SeoName { get; set; }
    }

    public class CuisineSet
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Cuisine> Cuisines { get; set; }
    }

    public class SeeAllSearchTarget
    {
        public List<object> CuisineFilters { get; set; }
        public string SortOrder { get; set; }
        public List<string> Refinements { get; set; }
    }

    public class ViewData
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public SeeAllSearchTarget SeeAllSearchTarget { get; set; }
        public List<object> FocusedProperties { get; set; }
    }

    public class Component
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string TrackingId { get; set; }
        public string TemplateName { get; set; }
        public ViewData ViewData { get; set; }
    }

    public class View
    {
        public string Target { get; set; }
        public List<Component> Components { get; set; }
    }

    public class ScoreMetadata
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class DeliveryEtaMinutes
    {
        public object Approximate { get; set; }
        public int RangeLower { get; set; }
        public int RangeUpper { get; set; }
    }

    public class CuisineType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SeoName { get; set; }
    }

    public class Logo
    {
        public string StandardResolutionURL { get; set; }
    }

    public class Restaurant
    {
        public List<object> Badges { get; set; }
        public double Score { get; set; }
        public double DriveDistance { get; set; }
        public bool DriveInfoCalculated { get; set; }
        public DateTime NewnessDate { get; set; }
        public int? DeliveryMenuId { get; set; }
        public DateTime? DeliveryOpeningTime { get; set; }
        public double DeliveryCost { get; set; }
        public double MinimumDeliveryValue { get; set; }
        public object DeliveryTimeMinutes { get; set; }
        public int? DeliveryWorkingTimeMinutes { get; set; }
        public string OpeningTime { get; set; }
        public DateTime? OpeningTimeIso { get; set; }
        public bool SendsOnItsWayNotifications { get; set; }
        public double RatingAverage { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<object> Tags { get; set; }
        public List<ScoreMetadata> ScoreMetadata { get; set; }
        public DeliveryEtaMinutes DeliveryEtaMinutes { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public List<CuisineType> CuisineTypes { get; set; }
        public string Url { get; set; }
        public bool IsOpenNow { get; set; }
        public bool IsPremier { get; set; }
        public bool IsSponsored { get; set; }
        public bool IsTemporaryBoost { get; set; }
        public int SponsoredPosition { get; set; }
        public bool IsNew { get; set; }
        public bool IsTemporarilyOffline { get; set; }
        public string ReasonWhyTemporarilyOffline { get; set; }
        public string UniqueName { get; set; }
        public bool IsCloseBy { get; set; }
        public bool IsHalal { get; set; }
        public bool IsTestRestaurant { get; set; }
        public int DefaultDisplayRank { get; set; }
        public bool IsOpenNowForDelivery { get; set; }
        public bool IsOpenNowForCollection { get; set; }
        public double RatingStars { get; set; }
        public List<Logo> Logo { get; set; }
        public List<object> Deals { get; set; }
        public int NumberOfRatings { get; set; }
        public bool ShowSmiley { get; set; }
        public int SmileyResult { get; set; }
        public string SmileyUrl { get; set; }
        public string SmileyElite { get; set; }
    }

    public class SearchedTerms
    {
        public object Phrase { get; set; }
        public object Postcode { get; set; }
        public object Cuisine { get; set; }
        public object CuisineSeoName { get; set; }
        public object City { get; set; }
    }

    public class TagDetail
    {
        public string Key { get; set; }
        public string DisplayName { get; set; }
        public string Colour { get; set; }
        public string BackgroundColour { get; set; }
        public int Priority { get; set; }
    }

    public class MetaData2
    {
        public SearchedTerms SearchedTerms { get; set; }
        public List<TagDetail> TagDetails { get; set; }
    }

}