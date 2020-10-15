﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeStoreAPI.Migrations
{
    public partial class intialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "production");

            migrationBuilder.EnsureSchema(
                name: "sales");

            migrationBuilder.CreateTable(
                name: "brands",
                schema: "production",
                columns: table => new
                {
                    brand_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand_name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__brands__5E5A8E27ED4D7F76", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "production",
                columns: table => new
                {
                    category_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__categori__D54EE9B48FB67C9E", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                schema: "sales",
                columns: table => new
                {
                    customer_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    last_name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    phone = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    email = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    street = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    city = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    state = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    zip_code = table.Column<string>(unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__customer__CD65CB85684947EC", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                schema: "sales",
                columns: table => new
                {
                    store_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    phone = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    email = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    street = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    city = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    state = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    zip_code = table.Column<string>(unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__stores__A2F2A30CFF586CDA", x => x.store_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "production",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    brand_id = table.Column<int>(nullable: false),
                    category_id = table.Column<int>(nullable: false),
                    model_year = table.Column<short>(nullable: false),
                    list_price = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__products__47027DF516749898", x => x.product_id);
                    table.ForeignKey(
                        name: "FK__products__brand___286302EC",
                        column: x => x.brand_id,
                        principalSchema: "production",
                        principalTable: "brands",
                        principalColumn: "brand_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__products__catego__276EDEB3",
                        column: x => x.category_id,
                        principalSchema: "production",
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "staffs",
                schema: "sales",
                columns: table => new
                {
                    staff_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    last_name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    phone = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    active = table.Column<byte>(nullable: false),
                    store_id = table.Column<int>(nullable: false),
                    manager_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__staffs__1963DD9CE2630114", x => x.staff_id);
                    table.ForeignKey(
                        name: "FK__staffs__manager___30F848ED",
                        column: x => x.manager_id,
                        principalSchema: "sales",
                        principalTable: "staffs",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__staffs__store_id__300424B4",
                        column: x => x.store_id,
                        principalSchema: "sales",
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stocks",
                schema: "production",
                columns: table => new
                {
                    store_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__stocks__E68284D39408DB47", x => new { x.store_id, x.product_id });
                    table.ForeignKey(
                        name: "FK__stocks__product___3E52440B",
                        column: x => x.product_id,
                        principalSchema: "production",
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__stocks__store_id__3D5E1FD2",
                        column: x => x.store_id,
                        principalSchema: "sales",
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "sales",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(nullable: true),
                    order_status = table.Column<byte>(nullable: false),
                    order_date = table.Column<DateTime>(type: "date", nullable: false),
                    required_date = table.Column<DateTime>(type: "date", nullable: false),
                    shipped_date = table.Column<DateTime>(type: "date", nullable: true),
                    store_id = table.Column<int>(nullable: false),
                    staff_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__orders__465962299EA003CF", x => x.order_id);
                    table.ForeignKey(
                        name: "FK__orders__customer__33D4B598",
                        column: x => x.customer_id,
                        principalSchema: "sales",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__orders__staff_id__35BCFE0A",
                        column: x => x.staff_id,
                        principalSchema: "sales",
                        principalTable: "staffs",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__orders__store_id__34C8D9D1",
                        column: x => x.store_id,
                        principalSchema: "sales",
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                schema: "sales",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false),
                    item_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    list_price = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(4, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__order_it__837942D4BC6CBFA9", x => new { x.order_id, x.item_id });
                    table.ForeignKey(
                        name: "FK__order_ite__order__398D8EEE",
                        column: x => x.order_id,
                        principalSchema: "sales",
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__order_ite__produ__3A81B327",
                        column: x => x.product_id,
                        principalSchema: "production",
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_brand_id",
                schema: "production",
                table: "products",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                schema: "production",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_product_id",
                schema: "production",
                table: "stocks",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_product_id",
                schema: "sales",
                table: "order_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_customer_id",
                schema: "sales",
                table: "orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_staff_id",
                schema: "sales",
                table: "orders",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_store_id",
                schema: "sales",
                table: "orders",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "UQ__staffs__AB6E6164D2C06805",
                schema: "sales",
                table: "staffs",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_staffs_manager_id",
                schema: "sales",
                table: "staffs",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "IX_staffs_store_id",
                schema: "sales",
                table: "staffs",
                column: "store_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stocks",
                schema: "production");

            migrationBuilder.DropTable(
                name: "order_items",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "products",
                schema: "production");

            migrationBuilder.DropTable(
                name: "customers",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "staffs",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "brands",
                schema: "production");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "production");

            migrationBuilder.DropTable(
                name: "stores",
                schema: "sales");
        }
    }
}
