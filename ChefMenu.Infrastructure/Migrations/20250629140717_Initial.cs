using System;
using System.Text.Json;
using ChefMenu.Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChefMenu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:category_type", "ingredients,kitchenwares")
                .Annotation("Npgsql:Enum:measurement_unit", "count,grams,milliliters")
                .Annotation("Npgsql:Enum:system_action_type", "create,hard_delete,soft_delete,update")
                .Annotation("Npgsql:Enum:user_action_type", "blacklist,dislike,like,save,view")
                .Annotation("Npgsql:Enum:user_feedback_status", "active,closed,open,resolved")
                .Annotation("Npgsql:Enum:user_feedback_type", "bug,feature,support")
                .Annotation("Npgsql:Enum:user_role", "admin,chef,cook,moderator,system")
                .Annotation("Npgsql:PostgresExtension:fuzzystrmatch", ",,")
                .Annotation("Npgsql:PostgresExtension:pg_trgm", ",,");

            migrationBuilder.CreateTable(
                name: "system_action_histories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    type = table.Column<SystemActionType>(type: "system_action_type", nullable: false),
                    entity_name = table.Column<string>(type: "text", nullable: false),
                    occurred_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    old = table.Column<JsonElement>(type: "jsonb", nullable: false),
                    @new = table.Column<JsonElement>(name: "new", type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_system_action_histories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'101', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<UserRole>(type: "user_role", nullable: false),
                    display_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    image_uri = table.Column<string>(type: "text", nullable: true),
                    rank = table.Column<int>(type: "integer", nullable: true),
                    is_public = table.Column<bool>(type: "boolean", nullable: false),
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    updated_by_id = table.Column<int>(type: "integer", nullable: true),
                    deleted_by_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_users_users_deleted_by_id",
                        column: x => x.deleted_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_users_users_updated_by_id",
                        column: x => x.updated_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    type = table.Column<CategoryType>(type: "category_type", nullable: false),
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    updated_by_id = table.Column<int>(type: "integer", nullable: true),
                    deleted_by_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    display_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    image_uri = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                    table.ForeignKey(
                        name: "fk_categories_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_categories_users_deleted_by_id",
                        column: x => x.deleted_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_categories_users_updated_by_id",
                        column: x => x.updated_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    updated_by_id = table.Column<int>(type: "integer", nullable: true),
                    deleted_by_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    display_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    image_uri = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ingredients", x => x.id);
                    table.ForeignKey(
                        name: "fk_ingredients_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ingredients_users_deleted_by_id",
                        column: x => x.deleted_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ingredients_users_updated_by_id",
                        column: x => x.updated_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "keywords",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    updated_by_id = table.Column<int>(type: "integer", nullable: true),
                    deleted_by_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    display_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_keywords", x => x.id);
                    table.ForeignKey(
                        name: "fk_keywords_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_keywords_users_deleted_by_id",
                        column: x => x.deleted_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_keywords_users_updated_by_id",
                        column: x => x.updated_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "kitchenwares",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    updated_by_id = table.Column<int>(type: "integer", nullable: true),
                    deleted_by_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    display_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    image_uri = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kitchenwares", x => x.id);
                    table.ForeignKey(
                        name: "fk_kitchenwares_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_kitchenwares_users_deleted_by_id",
                        column: x => x.deleted_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_kitchenwares_users_updated_by_id",
                        column: x => x.updated_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "recipe_collections",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    rank = table.Column<int>(type: "integer", nullable: true),
                    is_public = table.Column<bool>(type: "boolean", nullable: false),
                    updated_by_id = table.Column<int>(type: "integer", nullable: true),
                    deleted_by_id = table.Column<int>(type: "integer", nullable: true),
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    display_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    image_uri = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recipe_collections", x => x.id);
                    table.ForeignKey(
                        name: "fk_recipe_collections_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_recipe_collections_users_deleted_by_id",
                        column: x => x.deleted_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_recipe_collections_users_updated_by_id",
                        column: x => x.updated_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    content = table.Column<JsonElement>(type: "jsonb", nullable: false),
                    rank = table.Column<int>(type: "integer", nullable: true),
                    is_public = table.Column<bool>(type: "boolean", nullable: false),
                    updated_by_id = table.Column<int>(type: "integer", nullable: true),
                    deleted_by_id = table.Column<int>(type: "integer", nullable: true),
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    display_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    image_uri = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recipes", x => x.id);
                    table.ForeignKey(
                        name: "fk_recipes_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_recipes_users_deleted_by_id",
                        column: x => x.deleted_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_recipes_users_updated_by_id",
                        column: x => x.updated_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "system_configs",
                columns: table => new
                {
                    key = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<JsonElement>(type: "jsonb", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    updated_by_id = table.Column<int>(type: "integer", nullable: true),
                    deleted_by_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_system_configs", x => x.key);
                    table.ForeignKey(
                        name: "fk_system_configs_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_system_configs_users_deleted_by_id",
                        column: x => x.deleted_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_system_configs_users_updated_by_id",
                        column: x => x.updated_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_feedback",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    asigned_to_id = table.Column<int>(type: "integer", nullable: true),
                    type = table.Column<UserFeedbackType>(type: "user_feedback_type", nullable: false),
                    status = table.Column<UserFeedbackStatus>(type: "user_feedback_status", nullable: false),
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    updated_by_id = table.Column<int>(type: "integer", nullable: true),
                    deleted_by_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_feedback", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_feedback_users_asigned_to_id",
                        column: x => x.asigned_to_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_user_feedback_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_user_feedback_users_deleted_by_id",
                        column: x => x.deleted_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_user_feedback_users_updated_by_id",
                        column: x => x.updated_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "category_ingredient",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    ingredient_id = table.Column<int>(type: "integer", nullable: false),
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_ingredient", x => new { x.category_id, x.ingredient_id });
                    table.ForeignKey(
                        name: "fk_category_ingredient_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_category_ingredient_ingredients_ingredient_id",
                        column: x => x.ingredient_id,
                        principalTable: "ingredients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_category_ingredient_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "category_kitchenware",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    kitchenware_id = table.Column<int>(type: "integer", nullable: false),
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_kitchenware", x => new { x.category_id, x.kitchenware_id });
                    table.ForeignKey(
                        name: "fk_category_kitchenware_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_category_kitchenware_kitchenwares_kitchenware_id",
                        column: x => x.kitchenware_id,
                        principalTable: "kitchenwares",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_category_kitchenware_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "keyword_recipe_collection",
                columns: table => new
                {
                    keyword_id = table.Column<int>(type: "integer", nullable: false),
                    recipe_collection_id = table.Column<int>(type: "integer", nullable: false),
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_keyword_recipe_collection", x => new { x.keyword_id, x.recipe_collection_id });
                    table.ForeignKey(
                        name: "fk_keyword_recipe_collection_keywords_keyword_id",
                        column: x => x.keyword_id,
                        principalTable: "keywords",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_keyword_recipe_collection_recipe_collections_recipe_collect",
                        column: x => x.recipe_collection_id,
                        principalTable: "recipe_collections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_keyword_recipe_collection_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ingredient_recipe",
                columns: table => new
                {
                    ingredient_id = table.Column<int>(type: "integer", nullable: false),
                    recipe_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    measurement_unit = table.Column<MeasurementUnit>(type: "measurement_unit", nullable: false),
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ingredient_recipe", x => new { x.ingredient_id, x.recipe_id });
                    table.ForeignKey(
                        name: "fk_ingredient_recipe_ingredients_ingredient_id",
                        column: x => x.ingredient_id,
                        principalTable: "ingredients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ingredient_recipe_recipes_recipe_id",
                        column: x => x.recipe_id,
                        principalTable: "recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ingredient_recipe_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "keyword_recipe",
                columns: table => new
                {
                    keyword_id = table.Column<int>(type: "integer", nullable: false),
                    recipe_id = table.Column<int>(type: "integer", nullable: false),
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_keyword_recipe", x => new { x.keyword_id, x.recipe_id });
                    table.ForeignKey(
                        name: "fk_keyword_recipe_keywords_keyword_id",
                        column: x => x.keyword_id,
                        principalTable: "keywords",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_keyword_recipe_recipes_recipe_id",
                        column: x => x.recipe_id,
                        principalTable: "recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_keyword_recipe_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "kitchenware_recipe",
                columns: table => new
                {
                    kitchenware_id = table.Column<int>(type: "integer", nullable: false),
                    recipe_id = table.Column<int>(type: "integer", nullable: false),
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kitchenware_recipe", x => new { x.kitchenware_id, x.recipe_id });
                    table.ForeignKey(
                        name: "fk_kitchenware_recipe_kitchenwares_kitchenware_id",
                        column: x => x.kitchenware_id,
                        principalTable: "kitchenwares",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_kitchenware_recipe_recipes_recipe_id",
                        column: x => x.recipe_id,
                        principalTable: "recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_kitchenware_recipe_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "recipe_recipe_collection",
                columns: table => new
                {
                    recipe_id = table.Column<int>(type: "integer", nullable: false),
                    recipe_collection_id = table.Column<int>(type: "integer", nullable: false),
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recipe_recipe_collection", x => new { x.recipe_id, x.recipe_collection_id });
                    table.ForeignKey(
                        name: "fk_recipe_recipe_collection_recipe_collections_recipe_collecti",
                        column: x => x.recipe_collection_id,
                        principalTable: "recipe_collections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_recipe_recipe_collection_recipes_recipe_id",
                        column: x => x.recipe_id,
                        principalTable: "recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_recipe_recipe_collection_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    parent_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    recipe_id = table.Column<int>(type: "integer", nullable: true),
                    recipe_collection_id = table.Column<int>(type: "integer", nullable: true),
                    user_feedback_id = table.Column<int>(type: "integer", nullable: true),
                    text = table.Column<string>(type: "text", nullable: false),
                    updated_by_id = table.Column<int>(type: "integer", nullable: true),
                    deleted_by_id = table.Column<int>(type: "integer", nullable: true),
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comments", x => x.id);
                    table.CheckConstraint("ck_union", "   (parent_id IS NOT NULL)::int\r\n   + (user_id IS NOT NULL)::int\r\n   + (recipe_id IS NOT NULL)::int\r\n   + (recipe_collection_id IS NOT NULL)::int\r\n   + (user_feedback_id IS NOT NULL)::int\r\n   = 1");
                    table.ForeignKey(
                        name: "fk_comments_comments_parent_id",
                        column: x => x.parent_id,
                        principalTable: "comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_comments_recipe_collections_recipe_collection_id",
                        column: x => x.recipe_collection_id,
                        principalTable: "recipe_collections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_comments_recipes_recipe_id",
                        column: x => x.recipe_id,
                        principalTable: "recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_comments_user_feedback_user_feedback_id",
                        column: x => x.user_feedback_id,
                        principalTable: "user_feedback",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_comments_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_comments_users_deleted_by_id",
                        column: x => x.deleted_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_comments_users_updated_by_id",
                        column: x => x.updated_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_comments_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_actions",
                columns: table => new
                {
                    created_by_id = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<UserActionType>(type: "user_action_type", nullable: false),
                    chef_id = table.Column<int>(type: "integer", nullable: false),
                    ingredient_id = table.Column<int>(type: "integer", nullable: false),
                    kitchenware_id = table.Column<int>(type: "integer", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    keyword_id = table.Column<int>(type: "integer", nullable: false),
                    recipe_id = table.Column<int>(type: "integer", nullable: false),
                    recipe_collection_id = table.Column<int>(type: "integer", nullable: false),
                    comment_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_actions", x => new { x.created_by_id, x.type, x.chef_id, x.ingredient_id, x.kitchenware_id, x.category_id, x.keyword_id, x.recipe_id, x.recipe_collection_id, x.comment_id });
                    table.CheckConstraint("ck_union", "   (chef_id IS NOT NULL)::int\r\n   + (ingredient_id IS NOT NULL)::int\r\n   + (kitchenware_id IS NOT NULL)::int\r\n   + (category_id IS NOT NULL)::int\r\n   + (keyword_id IS NOT NULL)::int\r\n   + (recipe_id IS NOT NULL)::int\r\n   + (recipe_collection_id IS NOT NULL)::int\r\n   + (comment_id IS NOT NULL)::int\r\n   = 1");
                    table.ForeignKey(
                        name: "fk_user_actions_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_actions_comments_comment_id",
                        column: x => x.comment_id,
                        principalTable: "comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_actions_ingredients_ingredient_id",
                        column: x => x.ingredient_id,
                        principalTable: "ingredients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_actions_keywords_keyword_id",
                        column: x => x.keyword_id,
                        principalTable: "keywords",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_actions_kitchenwares_kitchenware_id",
                        column: x => x.kitchenware_id,
                        principalTable: "kitchenwares",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_actions_recipe_collections_recipe_collection_id",
                        column: x => x.recipe_collection_id,
                        principalTable: "recipe_collections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_actions_recipes_recipe_id",
                        column: x => x.recipe_id,
                        principalTable: "recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_actions_users_chef_id",
                        column: x => x.chef_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_actions_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_by_id", "deleted_at", "deleted_by_id", "description", "display_name", "email", "image_uri", "is_public", "password_hash", "rank", "role", "updated_at", "updated_by_id", "username" },
                values: new object[,]
                {
                    { 1, 1, null, null, "InternalSystem", "InternalSystem", "chefmenu.internal@gmail.com", null, false, "", null, UserRole.System, null, null, "InternalSystem" },
                    { 2, 1, null, null, "PublicSystem", "PublicSystem", "chefmenu.public@gmail.com", null, false, "", null, UserRole.System, null, null, "PublicSystem" },
                    { 3, 1, null, null, "AiSystem", "AiSystem", "chefmenu.ai@gmail.com", null, false, "", null, UserRole.System, null, null, "AiSystem" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_categories_created_by_id",
                table: "categories",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_categories_deleted_by_id",
                table: "categories",
                column: "deleted_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_categories_name",
                table: "categories",
                column: "name",
                unique: true)
                .Annotation("Npgsql:IndexInclude", new[] { "id" });

            migrationBuilder.CreateIndex(
                name: "ix_categories_name_fuzzy",
                table: "categories",
                column: "name")
                .Annotation("Npgsql:IndexMethod", "gist")
                .Annotation("Npgsql:IndexOperators", new[] { "gist_trgm_ops" });

            migrationBuilder.CreateIndex(
                name: "ix_categories_updated_by_id",
                table: "categories",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_ingredient_created_by_id",
                table: "category_ingredient",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_ingredient_ingredient_id",
                table: "category_ingredient",
                column: "ingredient_id")
                .Annotation("Npgsql:IndexInclude", new[] { "category_id" });

            migrationBuilder.CreateIndex(
                name: "ix_category_kitchenware_created_by_id",
                table: "category_kitchenware",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_kitchenware_kitchenware_id",
                table: "category_kitchenware",
                column: "kitchenware_id")
                .Annotation("Npgsql:IndexInclude", new[] { "category_id" });

            migrationBuilder.CreateIndex(
                name: "ix_comments_created_by_id",
                table: "comments",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_comments_deleted_by_id",
                table: "comments",
                column: "deleted_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_comments_parent_id",
                table: "comments",
                column: "parent_id",
                filter: "parent_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_comments_recipe_collection_id",
                table: "comments",
                column: "recipe_collection_id",
                filter: "recipe_collection_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_comments_recipe_id",
                table: "comments",
                column: "recipe_id",
                filter: "recipe_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_comments_updated_by_id",
                table: "comments",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_comments_user_feedback_id",
                table: "comments",
                column: "user_feedback_id",
                filter: "user_feedback_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_comments_user_id",
                table: "comments",
                column: "user_id",
                filter: "user_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_ingredient_recipe_created_by_id",
                table: "ingredient_recipe",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_ingredient_recipe_recipe_id",
                table: "ingredient_recipe",
                column: "recipe_id")
                .Annotation("Npgsql:IndexInclude", new[] { "ingredient_id" });

            migrationBuilder.CreateIndex(
                name: "ix_ingredients_created_by_id",
                table: "ingredients",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_ingredients_deleted_by_id",
                table: "ingredients",
                column: "deleted_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_ingredients_name",
                table: "ingredients",
                column: "name",
                unique: true)
                .Annotation("Npgsql:IndexInclude", new[] { "id" });

            migrationBuilder.CreateIndex(
                name: "ix_ingredients_name_fuzzy",
                table: "ingredients",
                column: "name")
                .Annotation("Npgsql:IndexMethod", "gist")
                .Annotation("Npgsql:IndexOperators", new[] { "gist_trgm_ops" });

            migrationBuilder.CreateIndex(
                name: "ix_ingredients_updated_by_id",
                table: "ingredients",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_keyword_recipe_created_by_id",
                table: "keyword_recipe",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_keyword_recipe_recipe_id",
                table: "keyword_recipe",
                column: "recipe_id")
                .Annotation("Npgsql:IndexInclude", new[] { "keyword_id" });

            migrationBuilder.CreateIndex(
                name: "ix_keyword_recipe_collection_created_by_id",
                table: "keyword_recipe_collection",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_keyword_recipe_collection_recipe_collection_id",
                table: "keyword_recipe_collection",
                column: "recipe_collection_id")
                .Annotation("Npgsql:IndexInclude", new[] { "keyword_id" });

            migrationBuilder.CreateIndex(
                name: "ix_keywords_created_by_id",
                table: "keywords",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_keywords_deleted_by_id",
                table: "keywords",
                column: "deleted_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_keywords_name",
                table: "keywords",
                column: "name",
                unique: true)
                .Annotation("Npgsql:IndexInclude", new[] { "id" });

            migrationBuilder.CreateIndex(
                name: "ix_keywords_name_fuzzy",
                table: "keywords",
                column: "name")
                .Annotation("Npgsql:IndexMethod", "gist")
                .Annotation("Npgsql:IndexOperators", new[] { "gist_trgm_ops" });

            migrationBuilder.CreateIndex(
                name: "ix_keywords_updated_by_id",
                table: "keywords",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_kitchenware_recipe_created_by_id",
                table: "kitchenware_recipe",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_kitchenware_recipe_recipe_id",
                table: "kitchenware_recipe",
                column: "recipe_id")
                .Annotation("Npgsql:IndexInclude", new[] { "kitchenware_id" });

            migrationBuilder.CreateIndex(
                name: "ix_kitchenwares_created_by_id",
                table: "kitchenwares",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_kitchenwares_deleted_by_id",
                table: "kitchenwares",
                column: "deleted_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_kitchenwares_name",
                table: "kitchenwares",
                column: "name",
                unique: true)
                .Annotation("Npgsql:IndexInclude", new[] { "id" });

            migrationBuilder.CreateIndex(
                name: "ix_kitchenwares_name_fuzzy",
                table: "kitchenwares",
                column: "name")
                .Annotation("Npgsql:IndexMethod", "gist")
                .Annotation("Npgsql:IndexOperators", new[] { "gist_trgm_ops" });

            migrationBuilder.CreateIndex(
                name: "ix_kitchenwares_updated_by_id",
                table: "kitchenwares",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_recipe_collections_created_by_id",
                table: "recipe_collections",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_recipe_collections_deleted_by_id",
                table: "recipe_collections",
                column: "deleted_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_recipe_collections_name_created_by_id",
                table: "recipe_collections",
                columns: new[] { "name", "created_by_id" },
                unique: true)
                .Annotation("Npgsql:IndexInclude", new[] { "id" });

            migrationBuilder.CreateIndex(
                name: "ix_recipe_collections_name_fuzzy",
                table: "recipe_collections",
                column: "name")
                .Annotation("Npgsql:IndexMethod", "gist")
                .Annotation("Npgsql:IndexOperators", new[] { "gist_trgm_ops" });

            migrationBuilder.CreateIndex(
                name: "ix_recipe_collections_updated_by_id",
                table: "recipe_collections",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_recipe_recipe_collection_created_by_id",
                table: "recipe_recipe_collection",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_recipe_recipe_collection_recipe_collection_id",
                table: "recipe_recipe_collection",
                column: "recipe_collection_id")
                .Annotation("Npgsql:IndexInclude", new[] { "recipe_id" });

            migrationBuilder.CreateIndex(
                name: "ix_recipes_created_by_id",
                table: "recipes",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_recipes_deleted_by_id",
                table: "recipes",
                column: "deleted_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_recipes_name_created_by_id",
                table: "recipes",
                columns: new[] { "name", "created_by_id" },
                unique: true)
                .Annotation("Npgsql:IndexInclude", new[] { "id" });

            migrationBuilder.CreateIndex(
                name: "ix_recipes_name_fuzzy",
                table: "recipes",
                column: "name")
                .Annotation("Npgsql:IndexMethod", "gist")
                .Annotation("Npgsql:IndexOperators", new[] { "gist_trgm_ops" });

            migrationBuilder.CreateIndex(
                name: "ix_recipes_updated_by_id",
                table: "recipes",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_system_configs_created_by_id",
                table: "system_configs",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_system_configs_deleted_by_id",
                table: "system_configs",
                column: "deleted_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_system_configs_updated_by_id",
                table: "system_configs",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_actions_category_id",
                table: "user_actions",
                column: "category_id",
                filter: "category_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_user_actions_chef_id",
                table: "user_actions",
                column: "chef_id",
                filter: "chef_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_user_actions_comment_id",
                table: "user_actions",
                column: "comment_id",
                filter: "comment_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_user_actions_ingredient_id",
                table: "user_actions",
                column: "ingredient_id",
                filter: "ingredient_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_user_actions_keyword_id",
                table: "user_actions",
                column: "keyword_id",
                filter: "keyword_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_user_actions_kitchenware_id",
                table: "user_actions",
                column: "kitchenware_id",
                filter: "kitchenware_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_user_actions_recipe_collection_id",
                table: "user_actions",
                column: "recipe_collection_id",
                filter: "recipe_collection_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_user_actions_recipe_id",
                table: "user_actions",
                column: "recipe_id",
                filter: "recipe_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_user_feedback_asigned_to_id",
                table: "user_feedback",
                column: "asigned_to_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_feedback_created_by_id",
                table: "user_feedback",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_feedback_deleted_by_id",
                table: "user_feedback",
                column: "deleted_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_feedback_updated_by_id",
                table: "user_feedback",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_created_by_id",
                table: "users",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_deleted_by_id",
                table: "users",
                column: "deleted_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true)
                .Annotation("Npgsql:IndexInclude", new[] { "id" });

            migrationBuilder.CreateIndex(
                name: "ix_users_updated_by_id",
                table: "users",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_username",
                table: "users",
                column: "username",
                unique: true)
                .Annotation("Npgsql:IndexInclude", new[] { "id" });

            migrationBuilder.CreateIndex(
                name: "ix_users_username_fuzzy",
                table: "users",
                column: "username")
                .Annotation("Npgsql:IndexMethod", "gist")
                .Annotation("Npgsql:IndexOperators", new[] { "gist_trgm_ops" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category_ingredient");

            migrationBuilder.DropTable(
                name: "category_kitchenware");

            migrationBuilder.DropTable(
                name: "ingredient_recipe");

            migrationBuilder.DropTable(
                name: "keyword_recipe");

            migrationBuilder.DropTable(
                name: "keyword_recipe_collection");

            migrationBuilder.DropTable(
                name: "kitchenware_recipe");

            migrationBuilder.DropTable(
                name: "recipe_recipe_collection");

            migrationBuilder.DropTable(
                name: "system_action_histories");

            migrationBuilder.DropTable(
                name: "system_configs");

            migrationBuilder.DropTable(
                name: "user_actions");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "keywords");

            migrationBuilder.DropTable(
                name: "kitchenwares");

            migrationBuilder.DropTable(
                name: "recipe_collections");

            migrationBuilder.DropTable(
                name: "recipes");

            migrationBuilder.DropTable(
                name: "user_feedback");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
