## Checkout Live Deployment on Link :- https://inlandtruckminiprojectdemo.onrender.com/

# 🚛 Truck Parts Inventory Explorer

A Blazor Web App built with **.NET 10** that decodes a vehicle VIN using the **NHTSA vPIC public API** and translates it into **Inland Truck Parts–relevant parts categories and service recommendations**.

---

## 📌 Overview

This project simulates how a commercial truck parts company like **Inland Truck Parts Company** could use VIN data to:

- Identify vehicle specifications
- Understand component-level requirements
- Guide parts selection and shop services

Instead of just displaying raw VIN data, this application adds a **business-aware recommendation layer** that maps vehicle attributes to **real-world parts and services**.

---

## ⚙️ Features

### 1️⃣ VIN Decode (API Integration)
- Accepts a 17-character VIN input
- Calls the **NHTSA vPIC public API**
- Retrieves structured vehicle data

---

### 2️⃣ Vehicle Profile Extraction
- Converts raw API data into a usable vehicle profile:
  - Make, Model, Year
  - Vehicle Type (Truck, Passenger, etc.)
  - Drive Type (4WD, AWD, etc.)
  - Engine details
  - Brake system
  - GVWR (if available)

- Handles missing API data gracefully

---

### 3️⃣ Parts & Service Recommendation Engine ⭐
A rule-based engine that maps decoded vehicle attributes to:

- **Relevant parts categories**
- **Service areas**
- **Relevance level (High / Medium / General)**
- **Business-specific reasoning**

#### Example:
| Category | Relevance | Reason | Inland Match |
|--------|--------|--------|--------|
| Driveline | High | Truck vehicle type detected | Driveline parts & repair services |
| Transfer Case | High | 4WD detected | Transfer case components |
| Brake System | High | Hydraulic brakes detected | Brake components & service |

This simulates how Inland could guide customers toward appropriate parts and services based on vehicle data.

---


## 🏗️ Tech Stack

- **Frontend:** Blazor Web App (.NET 10)
- **Backend Logic:** C#
- **API:** NHTSA vPIC (Vehicle Product Information Catalog)
- **Styling:** Custom CSS + Bootstrap

---


