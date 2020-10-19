1) How long did you spend on the coding test? What would you add to your solution if you had more time? If you didn't spend much time on the coding test then use this as an opportunity to explain what you would add.

1 A)    3 hour session deserializing the API response and solution setup within VS (created a web api).
        2 hour session getting the inner workings complete; Search functionality changing solution over to MVC rather than ajax.
        1 hour session working on styling of the search page, making it more user friendly, while ensuring the acceptance critea is met.
        30 mins writing this document.

        I would like to add a stand alone angular app, deisgned with rest endpoints, I would then create a seperate .net core api for and retrieval, sending and modification of data.

2) What was the most useful feature that was added to the latest version of your chosen language? Please include a snippet of code that shows how you've used it.

2 A)    While looking into the best practices for creating HttpClients I found a MSDN artcile on 'named clients'. This functionality allowed me to setup a JustEat specfic httpClient within the ConfigureServices method, setting all request headers and authentication upon startup of the project, meaning whenever I needed to hit the api it was a simple task of calling my JE specific client and sending through the postcode.

            services.AddHttpClient("justeat", c =>
            {
                c.BaseAddress = new Uri("https://public.je-apis.com");

                c.DefaultRequestHeaders.Add("Accept-Tenant", "uk");
                c.DefaultRequestHeaders.Add("Accept-Language", "en-GB");
                c.DefaultRequestHeaders.Add("Host", "public.je-apis.com");

                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue
                ("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_username}:{_password}")));
            });

            //////////////////////////////////////////////////

            var client = _clientFactory.CreateClient("justeat");

3) How would you track down a performance issue in production? Have you ever had to do this?

3 A)    Ideally rather vigurous logging would be in place, so the first port of call would be to check the application insights to see if there is any unsual behaviour. If nothing seems to be raising any flag then the infastructure should be checked next... Does the application have the resources it needs to operate at this point in time? Check the Requests, Average response time and CPU usage.

        The majority of my software development career has been spent within the realms of CMS based websites, therefore if consistant errors were being thrown only on production its very likely to be caused by a content issue. In this case, like previously mentioned I would firstly check the application insights, this would usually locate any issues to a URL, from here there are two main options; communicate with the client services team to figure out whether any content changes may have caused an issue, or connect to the live database from a local solution allowing the developer to see the YSOD error page

4) How would you improve the Just Eat APIs that you just used?

4 A)    Perhaps split the endpoints up or add parameters to mitigate the returned json. A simple request is rather cumbersome.

5) Please describe yourself using JSON.

5 A)

{
    "James": [
        {
            "Favourites": [{
                "Films":["Donnie Darko", "Good Will hunting", "Lost in translation"],
                "City":"Kyoto",
                "Food":"Squeezed Burger",
            }],
            "Hobbies": [{
                "Sport":["Basketball", "Football", "Running"],
                "leisure":["Architecture", "Cooking", "Travel"],
            }],
            "CoffeesPerDay":1,
        }
    ]
}


