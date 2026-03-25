# Onyx Industrial ERP Desktop

Desktop ERP application for production control, purchasing, inventory, commercial operations, maintenance, and reporting within the Onyx platform.

## Overview

**Onyx Industrial ERP Desktop** is the core desktop application of the Onyx ecosystem for managing industrial and operational processes. It centralizes key business functions in a unified Windows-based environment and serves as the main transactional and operational backbone of the platform.

Although production is one of its strongest components, the application also includes modules for purchasing, inventory, commercial operations, maintenance, and reporting, which makes it a broader ERP solution rather than a production-only system.

## Business Purpose

The purpose of this application is to support day-to-day industrial operations by providing a centralized desktop system for:

- production control
- purchasing management
- inventory-related processes
- commercial support functions
- maintenance and master data administration
- operational and management reporting

The repository represents the main desktop ERP layer of the Onyx platform.

## Main Functional Areas

### Production

The production area includes workflows and screens related to:

- work orders
- planning
- scheduling
- production summaries
- work order follow-up
- remissions
- production control
- validation processes
- responsibility and state changes

### Purchasing

The purchasing area supports tasks such as:

- price updates
- order search
- supplier remission consultation

### Commercial

The commercial area includes business support tools such as simulations.

### Inventory

The repository includes a dedicated inventory area as part of the project structure.

### Maintenance

The maintenance area supports administrative and configuration processes such as:

- operator maintenance
- responsible party maintenance
- plant area maintenance
- contracts
- permissions
- parameters
- state reversal and control

### Reporting

The reporting area includes forms and report definitions for:

- quotations
- inventory movements
- purchase orders
- production orders
- work orders
- programming
- remissions
- cost reports
- delivery reports
- exception reports

## Repository Structure

```text
Mod_Prod/
├── Conectividad/
├── ModProd/
│   ├── 00 Control de Cambios/
│   ├── Antiguos/
│   ├── Comercial/
│   ├── Compras/
│   ├── General/
│   ├── Inventario/
│   ├── Mantenimiento/
│   ├── My Project/
│   ├── Produccion/
│   ├── Reportes/
│   ├── Resources/
│   ├── Temp/
│   ├── img/
│   ├── app.config
│   ├── ModProd.vbproj
│   └── frmSeguimientoOT.vb
└── ModProd.sln
```

## Representative Functional Components

Examples of visible components in the current codebase include:

### Production
- `frmOrdenDeTrabajo`
- `frmPlaneacion`
- `frmProgramador`
- `frmResumenProduccion`
- `frmSeguimientoOT`
- `frmValidaResumenes`
- `frmValidacionRemision`
- `frmConsolaControl`
- `frmCambiaEstadosOT`
- `frmCambiaResponsable`
- `frmProductosOT`
- `frmRemision`

### Purchasing
- `frmActualizaPrecios`
- `frmBuscaOP`
- `frmBuscaRemisionesProveedores`

### Commercial
- `frmSimulador`
- `frmSimuladorRapida`

### Maintenance
- `frmMntOperarios`
- `frmMntResponsables`
- `frmMtoAreasPlanta`
- `frmMtoContratos`
- `frmMtoParametros`
- `frmMtoPermisos`
- `frmReversaEstadosOT`
- `frmMntMPNoCreada`
- `frmCambiaEstadosCot`

### Reporting
- `frmImprimeCotiza`
- `frmImprimeMov`
- `frmImprimeOC`
- `frmImprimeOP`
- `frmImprimeOT`
- `frmImprimeProg`
- `frmImprimeRemision`
- `frmRptCostosMP`
- `frmRptCotizacion`
- `frmRptEntregasArea`
- `frmRptMaterialesNoCreados`

## Technology Stack

Based on the current public repository structure, the application uses:

- **Language:** Visual Basic .NET
- **Application Style:** Windows desktop application
- **Project Type:** Visual Studio solution
- **Solution Projects:** `ModProd` and `Conectividad`

## Positioning

This repository should be positioned as the **main desktop ERP application** of the Onyx platform.

Even though the historical name suggests a production module, the current structure and functionality show that the solution supports a broader operational scope across multiple business areas.
