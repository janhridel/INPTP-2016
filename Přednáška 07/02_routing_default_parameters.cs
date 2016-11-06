void Application_Start(object sender, EventArgs e) 
{
    RegisterRoutes(RouteTable.Routes);
}

public static void RegisterRoutes(RouteCollection routes)
{
    routes.MapPageRoute("",
        "Category/{action}/{categoryName}",
        "~/categoriespage.aspx",
        true,
        new RouteValueDictionary 
            {{"categoryName", "food"}, {"action", "show"}});
}