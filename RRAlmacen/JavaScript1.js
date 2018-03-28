CREATE TABLE [dbo].[venta](
    [idventa]          INT            IDENTITY (1, 1) NOT NULL,
    [idcliente]        INT            NOT NULL,
    [idtrabajador]     INT            NOT NULL,
    [fecha]            DATE           NOT NULL,
    [tipo_comprobante] VARCHAR (20)   NOT NULL,
    [serie]            VARCHAR (4)    NOT NULL,
    [correlativo]      VARCHAR (7)    NOT NULL,
    [igv]              DECIMAL (4, 2) NOT NULL,
    CONSTRAINT[PK_venta] PRIMARY KEY CLUSTERED ([idventa] ASC),
    CONSTRAINT[FK_venta_cliente] FOREIGN KEY ([idcliente]) REFERENCES [dbo].[cliente]([idcliente])
);

CREATE TABLE [dbo].[proveedor](
    [idproveedor]      INT           IDENTITY (1, 1) NOT NULL,
    [razon_social]     VARCHAR (150) NOT NULL,
    [sector_comercial] VARCHAR (50)  NOT NULL,
    [tipo_documento]   VARCHAR (20)  NOT NULL,
    [num_documento]    VARCHAR (11)  NOT NULL,
    [direccion]        VARCHAR (100) NULL,
    [telefono]         VARCHAR (10)  NULL,
    [email]            VARCHAR (50)  NULL,
    [url]              VARCHAR (100) NULL,
    CONSTRAINT[PK_proveedor] PRIMARY KEY CLUSTERED ([idproveedor] ASC)
);
CREATE TABLE [dbo].[presentacion](
    [idpresentacion] INT           IDENTITY (1, 1) NOT NULL,
    [nombre]         VARCHAR (50)  NOT NULL,
    [descripcion]    VARCHAR (256) NULL,
    CONSTRAINT[PK_presentacion] PRIMARY KEY CLUSTERED ([idpresentacion] ASC)
);

CREATE TABLE [dbo].[detalle_venta](
    [iddetalle_venta]   INT   IDENTITY (1, 1) NOT NULL,
    [idventa]           INT   NOT NULL,
    [iddetalle_ingreso] INT   NOT NULL,
    [cantidad]          INT   NOT NULL,
    [precio_venta]      MONEY NOT NULL,
    [descuento]         MONEY NOT NULL,
    CONSTRAINT[PK_detalle_venta] PRIMARY KEY CLUSTERED ([iddetalle_venta] ASC),
    CONSTRAINT[FK_detalle_venta_detalle_ingreso] FOREIGN KEY ([iddetalle_ingreso]) REFERENCES [dbo].[detalle_ingreso]([iddetalle_ingreso]),
    CONSTRAINT[FK_detalle_venta_venta] FOREIGN KEY ([idventa]) REFERENCES [dbo].[venta]([idventa]) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE [dbo].[detalle_ingreso](
    [iddetalle_ingreso] INT   IDENTITY (1, 1) NOT NULL,
    [idingreso]         INT   NOT NULL,
    [idarticulo]        INT   NOT NULL,
    [precio_compra]     MONEY NOT NULL,
    [precio_venta]      MONEY NOT NULL,
    [stock_inicial]     INT   NOT NULL,
    [stock_actual]      INT   NOT NULL,
    [fecha_produccion]  DATE  NOT NULL,
    [fecha_vencimiento] DATE  NOT NULL,
    CONSTRAINT[PK_detalle_ingreso] PRIMARY KEY CLUSTERED ([iddetalle_ingreso] ASC),
    CONSTRAINT[FK_detalle_ingreso_articulo] FOREIGN KEY ([idarticulo]) REFERENCES [dbo].[articulo]([idarticulo])
);

CREATE TABLE [dbo].[cliente](
    [idcliente]        INT           IDENTITY (1, 1) NOT NULL,
    [nombre]           VARCHAR (50)  NOT NULL,
    [apellidos]        VARCHAR (40)  NULL,
    [sexo]             VARCHAR (1)   NULL,
    [fecha_nacimiento] DATE          NULL,
    [tipo_documento]   VARCHAR (20)  NOT NULL,
    [num_documento]    VARCHAR (11)  NOT NULL,
    [direccion]        VARCHAR (100) NULL,
    [telefono]         VARCHAR (10)  NULL,
    [email]            VARCHAR (50)  NULL,
    CONSTRAINT[PK_cliente] PRIMARY KEY CLUSTERED ([idcliente] ASC)
);

CREATE TABLE [dbo].[categoria](
    [idcategoria] INT           IDENTITY (1, 1) NOT NULL,
    [nombre]      VARCHAR (50)  NOT NULL,
    [descripcion] VARCHAR (256) NULL,
    CONSTRAINT[PK_categoria] PRIMARY KEY CLUSTERED ([idcategoria] ASC)
);

CREATE TABLE [dbo].[articulo](
    [idarticulo]     INT            IDENTITY (1, 1) NOT NULL,
    [codigo]         VARCHAR (50)   NOT NULL,
    [nombre]         VARCHAR (50)   NOT NULL,
    [descripcion]    VARCHAR (1024) NULL,
    [idcategoria]    INT            NOT NULL,
    [idpresentacion] INT            NOT NULL,
    [imagen]         IMAGE          NULL,
    CONSTRAINT[PK_articulo] PRIMARY KEY CLUSTERED ([idarticulo] ASC),
    CONSTRAINT[FK_articulo_categoria] FOREIGN KEY ([idcategoria]) REFERENCES [dbo].[categoria]([idcategoria]),
    CONSTRAINT[FK_articulo_presentacion] FOREIGN KEY ([idpresentacion]) REFERENCES [dbo].[presentacion]([idpresentacion])
);


