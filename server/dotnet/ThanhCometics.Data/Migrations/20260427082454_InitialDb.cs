using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThanhCometics.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    FunctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FunctionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.FunctionId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethodName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "ShippingPriceTables",
                columns: table => new
                {
                    ShippingPriceTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromWeight = table.Column<float>(type: "real", nullable: false),
                    ToWeight = table.Column<float>(type: "real", nullable: true),
                    InRegion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OutRegion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pir = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Por = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingPriceTables", x => x.ShippingPriceTableId);
                });

            migrationBuilder.CreateTable(
                name: "SkinTests",
                columns: table => new
                {
                    SkinTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkinTestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkinTests", x => x.SkinTestId);
                });

            migrationBuilder.CreateTable(
                name: "SkinTypes",
                columns: table => new
                {
                    SkinTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkinTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkinTypes", x => x.SkinTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TestTableThanhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTableThanhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    VoucherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoucherCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinimumPurchase = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.VoucherId);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                    table.ForeignKey(
                        name: "FK_Blogs_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    RefreshTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.RefreshTokenId);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRecommended = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkinTypeQuestions",
                columns: table => new
                {
                    SkinTypeQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<bool>(type: "bit", nullable: false),
                    SkinTestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkinTypeQuestions", x => x.SkinTypeQuestionId);
                    table.ForeignKey(
                        name: "FK_SkinTypeQuestions_SkinTests_SkinTestId",
                        column: x => x.SkinTestId,
                        principalTable: "SkinTests",
                        principalColumn: "SkinTestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmedEmail = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    SkinTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_SkinTypes_SkinTypeId",
                        column: x => x.SkinTypeId,
                        principalTable: "SkinTypes",
                        principalColumn: "SkinTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Routines",
                columns: table => new
                {
                    RoutineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoutineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    SkinTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routines", x => x.RoutineId);
                    table.ForeignKey(
                        name: "FK_Routines_SkinTypes_SkinTypeId",
                        column: x => x.SkinTypeId,
                        principalTable: "SkinTypes",
                        principalColumn: "SkinTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlogDetails",
                columns: table => new
                {
                    BlogDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    BlogDetailTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogDetailImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogDetails", x => x.BlogDetailId);
                    table.ForeignKey(
                        name: "FK_BlogDetails_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductFunctions",
                columns: table => new
                {
                    ProductFunctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    FunctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFunctions", x => x.ProductFunctionId);
                    table.ForeignKey(
                        name: "FK_ProductFunctions_Functions_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Functions",
                        principalColumn: "FunctionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductFunctions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ProductImageId);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductIngredients",
                columns: table => new
                {
                    ProductIngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Concentration = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductIngredients", x => x.ProductIngredientId);
                    table.ForeignKey(
                        name: "FK_ProductIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductIngredients_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSkinTypes",
                columns: table => new
                {
                    ProductSkinTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SkinTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSkinTypes", x => x.ProductSkinTypeId);
                    table.ForeignKey(
                        name: "FK_ProductSkinTypes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductSkinTypes_SkinTypes_SkinTypeId",
                        column: x => x.SkinTypeId,
                        principalTable: "SkinTypes",
                        principalColumn: "SkinTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkinTypeAnswers",
                columns: table => new
                {
                    SkinTypeAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkinTypeQuestionId = table.Column<int>(type: "int", nullable: false),
                    SkinTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkinTypeAnswers", x => x.SkinTypeAnswerId);
                    table.ForeignKey(
                        name: "FK_SkinTypeAnswers_SkinTypeQuestions_SkinTypeQuestionId",
                        column: x => x.SkinTypeQuestionId,
                        principalTable: "SkinTypeQuestions",
                        principalColumn: "SkinTypeQuestionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SkinTypeAnswers_SkinTypes_SkinTypeId",
                        column: x => x.SkinTypeId,
                        principalTable: "SkinTypes",
                        principalColumn: "SkinTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShippingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    VoucherId = table.Column<int>(type: "int", nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "VoucherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingAddresses",
                columns: table => new
                {
                    ShippingAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddresses", x => x.ShippingAddressId);
                    table.ForeignKey(
                        name: "FK_ShippingAddresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoutineDetails",
                columns: table => new
                {
                    RoutineDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoutineDetailName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoutineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineDetails", x => x.RoutineDetailId);
                    table.ForeignKey(
                        name: "FK_RoutineDetails_Routines_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routines",
                        principalColumn: "RoutineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoutineSteps",
                columns: table => new
                {
                    RoutineStepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Step = table.Column<int>(type: "int", nullable: false),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoutineDetailId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineSteps", x => x.RoutineStepId);
                    table.ForeignKey(
                        name: "FK_RoutineSteps_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoutineSteps_RoutineDetails_RoutineDetailId",
                        column: x => x.RoutineDetailId,
                        principalTable: "RoutineDetails",
                        principalColumn: "RoutineDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogDetails_BlogId",
                table: "BlogDetails",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AccountId",
                table: "Blogs",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountId",
                table: "Customers",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SkinTypeId",
                table: "Customers",
                column: "SkinTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CustomerId",
                table: "Feedbacks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ProductId",
                table: "Feedbacks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VoucherId",
                table: "Orders",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFunctions_FunctionId",
                table: "ProductFunctions",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFunctions_ProductId",
                table: "ProductFunctions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductIngredients_IngredientId",
                table: "ProductIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductIngredients_ProductId",
                table: "ProductIngredients",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSkinTypes_ProductId",
                table: "ProductSkinTypes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSkinTypes_SkinTypeId",
                table: "ProductSkinTypes",
                column: "SkinTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_AccountId",
                table: "RefreshTokens",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineDetails_RoutineId",
                table: "RoutineDetails",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_Routines_SkinTypeId",
                table: "Routines",
                column: "SkinTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineSteps_CategoryId",
                table: "RoutineSteps",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineSteps_RoutineDetailId",
                table: "RoutineSteps",
                column: "RoutineDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_CustomerId",
                table: "ShippingAddresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SkinTypeAnswers_SkinTypeId",
                table: "SkinTypeAnswers",
                column: "SkinTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SkinTypeAnswers_SkinTypeQuestionId",
                table: "SkinTypeAnswers",
                column: "SkinTypeQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SkinTypeQuestions_SkinTestId",
                table: "SkinTypeQuestions",
                column: "SkinTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_OrderId",
                table: "Transactions",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogDetails");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductFunctions");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductIngredients");

            migrationBuilder.DropTable(
                name: "ProductSkinTypes");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RoutineSteps");

            migrationBuilder.DropTable(
                name: "ShippingAddresses");

            migrationBuilder.DropTable(
                name: "ShippingPriceTables");

            migrationBuilder.DropTable(
                name: "SkinTypeAnswers");

            migrationBuilder.DropTable(
                name: "TestTableThanhs");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RoutineDetails");

            migrationBuilder.DropTable(
                name: "SkinTypeQuestions");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Routines");

            migrationBuilder.DropTable(
                name: "SkinTests");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "SkinTypes");
        }
    }
}
