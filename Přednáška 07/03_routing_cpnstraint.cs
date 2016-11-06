public static void RegisterRoutes(RouteCollection routes)
{
    routes.MapPageRoute("",
        "Category/{action}/{categoryName}",
        "~/categoriespage.aspx",
        true,
        new RouteValueDictionary 
            {{"categoryName", "food"}, {"action", "show"}},
        new RouteValueDictionary 
            {{"locale", "[a-z]{2}-[a-z]{2}"},{"year", @"\d{4}"}}
       );
}