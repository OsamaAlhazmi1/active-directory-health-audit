# Active Directory Health & Audit

Enterprise-style Active Directory health monitoring and auditing dashboard built with ASP.NET Core, Blazor Server, Entity Framework Core, and LDAP/LDAPS.

The project provides a centralized dashboard for monitoring Active Directory users, computers, groups, domains, and domain controller availability.

---

## Overview

Active Directory environments contain a large amount of information that administrators need to monitor regularly.

This project provides a web-based dashboard that collects and presents Active Directory-related health and audit information in a centralized interface.

The application is designed around two main components:

- **ASP.NET Core API** — Handles business logic, database access, dashboard aggregation, and Active Directory integration.
- **Blazor Server UI** — Provides the web interface for viewing health and audit information.

The application also uses a local database to store and organize monitoring data.

---

## Features

### Dashboard

The main dashboard provides an overview of the Active Directory environment, including:

- Total users
- Enabled users
- Disabled users
- Users with expired passwords
- Total computers
- Enabled computers
- Disabled computers
- Total groups
- Domain controller count
- Available domain controllers
- Unavailable domain controllers
- Overall domain health status

### Domain Health

The dashboard provides domain-level health information and displays:

- Domain controllers
- Controller availability
- Domain health status
- Controller connectivity state

Health status is dynamically determined based on domain controller availability.

### Domain Controllers

The application provides a dedicated view of domain controllers and their current connectivity status.

Example states:

- Available
- Unavailable



## Architecture

The application follows a separation between the presentation layer, API, and data layer.

```text
                         ┌──────────────────────┐
                         │        User          │
                         │   Web Browser        │
                         └──────────┬───────────┘
                                    │
                                    ▼
                         ┌──────────────────────┐
                         │   Blazor Server UI   │
                         │      AD.HealthAudit  │
                         │          .UI         │
                         └──────────┬───────────┘
                                    │
                              HTTP / HTTPS
                                    │
                                    ▼
                         ┌──────────────────────┐
                         │    ASP.NET Core API  │
                         │      AD.HealthAudit  │
                         │          .API        │
                         └──────────┬───────────┘
                                    │
                       ┌────────────┴────────────┐
                       │                         │
                       ▼                         ▼
              ┌────────────────┐       ┌──────────────────┐
              │   EF Core      │       │ Active Directory │
              │                │       │   LDAP / LDAPS   │
              └───────┬────────┘       └──────────────────┘
                      │
                      ▼
              ┌────────────────┐
              │ Local Database │
              │     SQLite     │
              └────────────────┘
