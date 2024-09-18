using ecommer;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet(
    "",
    () =>
    {
        return "backend projetc";
    }
);

List<Product> prodcuts = new List<Product>
{
    new Product
    {
        Id = 1,
        ProductName = "labtop",
        Price = 1000,
        Description = "good labtop",
        StockQuantity = 22,
    },
    new Product
    {
        Id = 2,
        ProductName = "mobile",
        Price = 200,
        Description = "good mobile",
        StockQuantity = 12,
    },
    new Product
    {
        Id = 3,
        ProductName = "tablet",
        Price = 300,
        Description = "good tablet",
        StockQuantity = 22,
    },
};

List<User> users = new List<User>
{
    new User
    {
        UserId = 1,
        FristName = "Asma",
        LastName = "Alsaleh",
        Address = "Khamis Mushait",
        Email = "asma@example.com",
        Password = "Abc1",
    },
    new User
    {
        UserId = 2,
        FristName = "Areej",
        LastName = "Alkhaldi",
        Address = "good mobile",
        Email = "areej@example.com",
        Password = "Def2",
    },
    new User
    {
        UserId = 3,
        FristName = "Jana",
        LastName = "Alghasham",
        Address = "good tablet",
        Email = "jana@example.com",
        Password = "Ghi3",
    },
    new User
    {
        UserId = 3,
        FristName = "Norah",
        LastName = "Aldawsari",
        Address = "good tablet",
        Email = "norah@example.com",
        Password = "Jkl4",
    },
    new User
    {
        UserId = 3,
        FristName = "Taif",
        LastName = "Alahmadi",
        Address = "good tablet",
        Email = "taif@example.com",
        Password = "Mno5",
    },
};

List<Category> categories = new List<Category>
{
    new Category { CategoryId = 1, CategoryName = "Phones" },
    new Category { CategoryId = 2, CategoryName = "Electronic" },
};

app.MapGet(
    "/api/v1/products",
    () =>
    {
        return Results.Ok(prodcuts);
    }
);

app.MapGet(
    "/api/v1/products/{id}",
    (int id) =>
    {
        Product? product = prodcuts.FirstOrDefault(p => p.Id == id);
        return product is not null ? Results.Ok(product) : Results.NotFound();
    }
);

app.MapPost(
    "/api/v1/products",
    (Product newProduct) =>
    {
        prodcuts.Add(newProduct);
        return Results.Created("new product", newProduct);
    }
);

app.MapPut(
    "/api/v1/products/{id}",
    (int id, Product updatedProduct) =>
    {
        Product? foundProduct = prodcuts.FirstOrDefault(p => p.Id == id);
        if (foundProduct == null)
        {
            return Results.NotFound();
        }
        foundProduct.ProductName = updatedProduct.ProductName;
        return Results.Ok(foundProduct);
    }
);

app.MapDelete(
    "/api/v1/products/{id}",
    (int id) =>
    {
        Product? foundProduct = prodcuts.FirstOrDefault(p => p.Id == id);

        if (foundProduct == null)
        {
            return Results.NotFound();
        }
        prodcuts.Remove(foundProduct);
        return Results.NoContent();
    }
);

app.MapGet("/api/v1/users", () => users);
app.MapGet(
    "/api/v1/users/{id}",
    (int id) =>
    {
        User? user = users.FirstOrDefault(p => p.UserId == id);
        return user is not null ? Results.Ok(user) : Results.NotFound();
    }
);
app.MapPost(
    "/api/v1/users",
    (User newUser) =>
    {
        if (newUser.UserId == 0)
            newUser.UserId = users.Max(u => u.UserId) + 1;
        users.Add(newUser);
        return Results.Created($"/api/v1/users/{newUser.UserId}", newUser);
    }
);
app.MapPut(
    "/api/v1/users/{userId}",
    (int userId, User updatedUser) =>
    {
        var user = users.FirstOrDefault(u => u.UserId == userId);
        if (user == null)
            return Results.NotFound();
        user.FristName = updatedUser.FristName;
        user.LastName = updatedUser.LastName;
        return Results.Ok(user);
    }
);
app.MapDelete(
    "/api/v1/users/{userId}",
    (int userId) =>
    {
        var user = users.FirstOrDefault(u => u.UserId == userId);
        if (user == null)
            return Results.NotFound();
        users.Remove(user);
        return Results.NoContent();
    }
);

app.MapGet(
    "/api/v1/categories",
    () =>
    {
        return Results.Ok(categories);
    }
);

// Get a single category
app.MapGet(
    "/api/v1/categories/{id}",
    (int id) =>
    {
        Category? category = categories.FirstOrDefault(p => p.CategoryId == id);
        return category is not null ? Results.Ok(category) : Results.NotFound();
    }
);

// Create a new category
app.MapPost(
    "/api/v1/categories",
    (Category category) =>
    {
        categories.Add(category);
        return Results.Created("new category", category);
    }
);

// Update a category
app.MapPut(
    "/api/v1/categories/{id}",
    (int id, Category UpdateCategory) =>
    {
        Category? foundcategory = categories.FirstOrDefault(p => p.CategoryId == id);
        if (foundcategory == null)
        {
            return Results.NotFound();
        }
        foundcategory.CategoryName = UpdateCategory.CategoryName;
        return Results.Ok(foundcategory);
    }
);

// Remove a category
app.MapDelete(
    "/api/v1/categories/{id}",
    (int id) =>
    {
        Category? foundCategory = categories.FirstOrDefault(p => p.CategoryId == id);

        if (foundCategory == null)
        {
            return Results.NotFound();
        }
        categories.Remove(foundCategory);
        return Results.NoContent();
    }
);

app.Run();
