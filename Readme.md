<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128636898/10.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2394)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Appointment.cs](./CS/DevExpress.Calendar.Model/Appointment.cs) (VB: [Appointment.vb](./VB/DevExpress.Calendar.Model/Appointment.vb))
* [Appointment.Shared.cs](./CS/DevExpress.Calendar.Model/Appointment.Shared.cs) (VB: [Appointment.Shared.vb](./VB/DevExpress.Calendar.Model/Appointment.Shared.vb))
* [Resource.cs](./CS/DevExpress.Calendar.Model/Resource.cs) (VB: [Resource.Shared.vb](./VB/DevExpress.Calendar.Model/Resource.Shared.vb))
* [Resource.Shared.cs](./CS/DevExpress.Calendar.Model/Resource.Shared.cs) (VB: [Resource.Shared.vb](./VB/DevExpress.Calendar.Model/Resource.Shared.vb))
* [Service.svc.cs](./CS/DevExpress.Calendar.Web/Service.svc.cs) (VB: [Service.svc.vb](./VB/DevExpress.Calendar.Web/Service.svc.vb))
* [Home.cs](./CS/DevExpress.Calendar/Parts/Home.cs) (VB: [Home.vb](./VB/DevExpress.Calendar/Parts/Home.vb))
<!-- default file list end -->
# Using WCF Data Services with XPO Data Service Provider for the XtraScheduler data binding


<p><strong>XPO now ships with the integrated suppor</strong><strong>t of the Open Data Protocol V2 (OData)</strong> so this example is not relevant for versions v2011 vol.2.5 and higher.</p><p>This example illustrates the use of the XPO Toolkit for binding the <a href="http://www.odata.org/"><u>Open Data Protocol (OData)</u></a> feeds exposed via the <a href="http://xpo.codeplex.com/"><u>XPO Data Service Provider</u></a> to a Scheduler.</p><p>The Open Data Protocol is a Web protocol for querying and updating data from a variety of sources. You can use the WCF Data Services to expose your data via this protocol. If your application is built upon the XPO with its specific data model, you'll need a data provider for XPO to connect to the WCF Data Services. Successfully the required data provider exists and can be downloaded from CodePlex at the <a href="http://xpo.codeplex.com/"><u>eXpress Persistent Objects (XPO) Toolkit</u></a> site. </p><p>This example consists of three projects. The DevExpress.Calendar.Web project implements WCF Data service (operating at fixed port 60996). The DevExpress.Calendar.Model project contains XPO data model, and the DevExpress.Calendar project displays the Scheduler control bound to XPO data. </p><p>To run the example, a running local SQLExpress server is required. <br />
To create a database with data tables and fill them with data, run tests for the DevExpress.Calendar.Web project.<br />
This step can't be avoided. Run tests for the DevExpress.Calendar.Web project - this action creates data tables in the database and fill the tables with sample data. To accomplish this, right-click the project in the Solution Explorer and select the 'Run test(s)' item in the context menu.<br />
Now you can build the solution and run it.</p><p>Note that the data model used in this example is quite simple and does not support resource sharing, recurring appointments and reminders.</p><p><strong>See Also:</strong><br />
<a href="http://community.devexpress.com/blogs/theonewith/archive/2010/05/21/odata-data-service-provider-for-xpo.aspx"><u>OData Provider for XPO - Introduction</u></a></p>

<br/>


