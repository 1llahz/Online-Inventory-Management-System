<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="brandlist.aspx.cs" Inherits="onlineinventory.brandlist" %>






<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
	<meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0"/>
    <meta name="description" content="POS - Bootstrap Admin Template"/>
	<meta name="keywords" content="admin, estimates, bootstrap, business, corporate, creative, invoice, html5, responsive, Projects"/>
    <meta name="author" content="Dreamguys - Bootstrap Admin Template"/>
    <meta name="robots" content="noindex, nofollow"/>
    <title>Dreams Pos inventory</title>
	
	<!-- Favicon -->
    <link rel="shortcut icon" type="image/x-icon" href="assets/img/favicon.png"/>
	
	<!-- Bootstrap CSS -->
    <link rel="stylesheet" href="assets/css/bootstrap.min.css"/>

	<!-- Datetimepicker CSS -->
	<link rel="stylesheet" href="assets/css/bootstrap-datetimepicker.min.css"/>
	
	<!-- animation CSS -->
    <link rel="stylesheet" href="assets/css/animate.css"/>

	<!-- Select2 CSS -->
	<link rel="stylesheet" href="assets/plugins/select2/css/select2.min.css"/>

	<!-- Datatable CSS -->
	<link rel="stylesheet" href="assets/css/dataTables.bootstrap4.min.css"/>
	
    <!-- Fontawesome CSS -->
	<link rel="stylesheet" href="assets/plugins/fontawesome/css/fontawesome.min.css"/>
	<link rel="stylesheet" href="assets/plugins/fontawesome/css/all.min.css"/>
	
	<!-- Main CSS -->
    <link rel="stylesheet" href="assets/css/style.css"/>
	


   

</head>
<body>
   
      
		<div id="global-loader" >
			<div class="whirly-loader"> </div>
		</div>
		<!-- Main Wrapper -->
		<div class="main-wrapper">

			<!-- Header -->
			<div class="header">
			
				<!-- Logo -->
				 <div class="header-left active">
					<a href="index.aspx" class="logo logo-normal">
						<img src="assets/img/logo.png"  alt=""/>
					</a>
					<a href="index.aspx" class="logo logo-white">
						<img src="assets/img/logo-white.png"  alt=""/>
					</a>
					<a href="index.aspx" class="logo-small">
						<img src="assets/img/logo-small.png"  alt=""/>
					</a>
					<a id="toggle_btn" href="javascript:void(0);">
						<i data-feather="chevrons-left" class="feather-16"></i>
					</a>
				</div>
				<!-- /Logo -->
				
				<a id="mobile_btn" class="mobile_btn" href="#sidebar">
					<span class="bar-icon">
						<span></span>
						<span></span>
						<span></span>
					</span>
				</a>
				
				<!-- Header Menu -->
				<ul class="nav user-menu">
				
					<!-- Search -->
					<li class="nav-item nav-searchinputs"/>
						
							
			
					
					<li class="nav-item nav-item-box">
						<a href="generalsettings.aspx"><i data-feather="settings"></i></a>
					</li>
			   
					<li class="nav-item dropdown has-arrow main-drop">

						<a href="javascript:void(0);" class="dropdown-toggle nav-link userset" data-bs-toggle="dropdown">
							<span class="user-info">
								<span class="user-letter">
									<img src="Taroo Icon.jpeg" alt="" class="auto-style1"/>
								</span>
								<span class="user-detail">
									<span class="user-name">Aisha Hassan</span>
									<span class="user-role">Admin</span>
								</span>
							</span>
						</a>
						<div class="dropdown-menu menu-drop-user">
							<div class="profilename">
								<div class="profileset">
									<span class="user-img"><img src="Taroo Icon.jpeg" alt="" />
									<span class="status online"></span></span>
									<div class="profilesets">
										<h6>Aisha Hassan</h6>
										<h5>Admin</h5>
									</div>
								</div>
								<hr class="m-0"/>
								<a class="dropdown-item" href="profile.aspx"> <i class="me-2"  data-feather="user"></i> My Profile</a>
								<a class="dropdown-item" href="generalsettings.aspx"><i class="me-2" data-feather="settings"></i>Settings</a>
								<hr class="m-0"/>
								<a class="dropdown-item logout pb-0" href="singin.aspx"><img src="assets/img/icons/log-out.svg" class="me-2" alt="img"/>Logout</a>
							</div>
						</div>
					</li>
					 
				</ul>
				</div>
				<!-- /Header Menu -->
				
				<!-- Mobile Menu -->
				<div class="dropdown mobile-user-menu">
					<a href="javascript:void(0);" class="nav-link dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
					<div class="dropdown-menu dropdown-menu-right">
						<a class="dropdown-item" href="profile.html">My Profile</a>
						<a class="dropdown-item" href="generalsettings.html">Settings</a>
						<a class="dropdown-item" href="singin.aspx">Logout</a>
					</div>
				</div>
				<!-- /Mobile Menu -->
			</div>
			<!-- Header -->

			
			<!-- Sidebar -->
						<div class="sidebar" id="sidebar">
	<div class="sidebar-inner slimscroll">
		<div id="sidebar-menu" class="sidebar-menu">
			<ul>
				<li class="submenu-open">
					<h6 class="submenu-hdr">Main</h6>
					<ul>
						<li class="active">
							<a href="index.aspx" ><i data-feather="grid"></i><span>Dashboard</span></a>
						</li>
					
					</ul>								
				</li>


				<li class="submenu-open">
					<h6 class="submenu-hdr">Products</h6>
					<ul>
					<li class="submenu">
					<a href="javascript:void(0);"><i data-feather="box"></i><span> Product</span> <span class="menu-arrow"></span></a>

					<ul>
						<li><a href="productlist.aspx"><i data-feather="box"></i><span>Product List</span></a></li>
						<li><a href="addproduct.aspx"><i data-feather="plus-square"></i><span>Add Product</span></a></li>
						<li><a href="categorylist.aspx"><i data-feather="codepen"></i><span>Category</span></a></li>
						<li><a href="addcategory.aspx"><i data-feather="codepen"></i><span>Add Category</span></a></li>
						<li><a href="brandlist.aspx"><i data-feather="tag"></i><span>Brands</span></a></li>
						<li><a href="addbrand.aspx"><i data-feather="tag"></i><span>Add Brands</span></a></li>
						<li><a href="subcategorylist.aspx"><i data-feather="speaker"></i><span>Sub Category</span></a></li>	
						<li><a href="addsubcategory.aspx"><i data-feather="speaker"></i><span>Add Sub Category</span></a></li>	
					</ul>
						</li>
					</ul>
				</li>
				<li class="submenu-open">
					<h6 class="submenu-hdr">Sales</h6>
						<ul>
						<li class="submenu">
						<a href="javascript:void(0);"><i data-feather="shopping-cart"></i><span>Sales</span><span class="menu-arrow"></span></a>
					<ul>
						<li><a href="saleslist.aspx"><i data-feather="shopping-cart"></i><span>Sales List</span></a></li>
						<li><a href="addsales.aspx"><i data-feather="shopping-cart"></i><span>Add Sales </span></a></li>

						
						
					</ul>
						</li>
						</ul>
				</li>
				<li class="submenu-open">
					<h6 class="submenu-hdr">Purchases</h6>
					<ul>
					 <li class="submenu">
					     <a href="javascript:void(0);"><i data-feather="shopping-bag"></i><span>Purchases</span><span class="menu-arrow"></span></a>
					<ul> 		
						<li><a href="purchaselist.aspx"><i data-feather="shopping-bag"></i><span>Purchases List </span></a></li>

						<li><a href="addpurchase.aspx"><i data-feather="shopping-bag"></i><span>add Purchases </span></a></li>
					</ul>
						 </li>
					</ul>
				</li>
				<li class="submenu-open">
					<h6 class="submenu-hdr">Finance & Accounts</h6>								
					<ul>
						<li class="submenu">
							<a href="javascript:void(0);"><i data-feather="file-text"></i><span>Finance</span><span class="menu-arrow"></span></a>
							<ul>
							<li><a href="paymentlist.aspx"> payment List</a></li>
							<li><a href="addpayment.aspx">Add Payments</a></li>
							</ul>
						</li>
					</ul>
				</li>
				<li class="submenu-open">
					<h6 class="submenu-hdr">Peoples</h6>
						<ul>
						 <li class="submenu">
						<a href="javascript:void(0);"><i data-feather="user"></i><span>Transactions</span><span class="menu-arrow"></span></a>
					<ul>
						<li><a href="addcustomer.aspx"><i data-feather="user"></i><span>Add Customers </span></a></li>
						<li><a href="addsupplier.aspx"><i data-feather="users"></i><span>Add Suppliers</span></a></li>
						<li><a href="addstore.aspx"><i data-feather="home"></i><span>Add Stores</span></a></li>
					</ul>
					     </li>
					  </ul>
				</li>
				<li class="submenu-open">
					<h6 class="submenu-hdr">Reports</h6>
					<ul>
					<li class="submenu">
						<a href="javascript:void(0);"><i data-feather="bar-chart-2"></i><span>Manage Reports</span><span class="menu-arrow"></span></a>
					<ul>
						
						<li><a href="salesreport.aspx"><i data-feather="bar-chart-2"></i><span>Sales Report</span></a></li>
						<li><a href="purchasereport.aspx"><i data-feather="bar-chart"></i><span>Purchase Report</span></a></li>
						<li><a href="supplierreport.aspx"><i data-feather="database"></i><span>Supplier Report</span></a></li>
						<li><a href="customerreport.aspx"><i data-feather="pie-chart"></i><span>Customer Report</span></a></li>
						
					</ul>
					</li>
					</ul>
				</li>															
				<li class="submenu-open">
					<h6 class="submenu-hdr">User Management</h6>		
					<ul>
						<li class="submenu">
							<a href="javascript:void(0);"><i data-feather="users"></i><span>Manage Users</span><span class="menu-arrow"></span></a>
							<ul>
								<li><a href="newuser.aspx">New User </a></li>
								<li><a href="userlists.aspx">Users List</a></li>
							</ul>
						</li>
					</ul>
				</li>			
				
				<li class="submenu-open"> 
					<ul>
				<li class="submenu-open">
					<h6 class="submenu-hdr">Settings</h6>		
					<ul>
						<li class="submenu">
							<a href="javascript:void(0);"><i data-feather="settings"></i><span>Settings</span><span class="menu-arrow"></span></a>
							<ul>
								<li><a href="singin.aspx">Sing In</a></li>
							</ul>
						</li>
						<li>
							<a href="singin.aspx" ><i data-feather="log-out"></i><span>Logout</span> </a>
						</li>
					</ul>
				</li>
			</ul>
				</li>
			</ul>
		</div>
	</div>
</div>
			<!-- /Sidebar -->
		<!-- product list registration form starts here-->
	  	  
		    
		<div class="page-wrapper">
				<div class="content">
					<div class="page-header">
						<div class="page-title">
							<h4>Brand List</h4>
							<h6>Manage your Brand</h6>
						</div>
						<div class="page-btn">
							<a href="addbrand.aspx" class="btn btn-added"><img src="assets/img/icons/plus.svg"  class="me-2" alt="img"/>Add Brand</a>
						</div>
					</div>
			
		<!-- /product list -->
		 <form id="form1" runat="server">
		<div class="card">
			<div class="card-body">
				<div class="table-top">
					<div class="search-set">
						<div class="search-path">
							<a class="btn btn-filter" id="filter_search">
								<img src="assets/img/icons/filter.svg" alt="img"/>
								<span><img src="assets/img/icons/closes.svg" alt="img"/></span>
							</a>
						</div>
						<div class="search-input">
							<a class="btn btn-searchset"><img src="assets/img/icons/search-white.svg" alt="img"/></a>
						</div>
					</div>
					<div class="wordset">
						<ul>
							<li>
								<a data-bs-toggle="tooltip" data-bs-placement="top" title="pdf"><img src="assets/img/icons/pdf.svg" alt="img"/></a>
							</li>
							<li>
								<a data-bs-toggle="tooltip" data-bs-placement="top" title="excel"><img src="assets/img/icons/excel.svg" alt="img"/></a>
							</li>
							<li>
								<a data-bs-toggle="tooltip" data-bs-placement="top" title="print"><img src="assets/img/icons/printer.svg" alt="img"/></a>
							</li>
						</ul>
					</div>
				</div>
				
			</div>
		</div>

       

             <asp:GridView ID="GridView2" CssClass="table table-bordered table-sm table-hover" runat="server" DataSourceID="SqlDataSource1"></asp:GridView>


             <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:Inventory_dbConnectionString9 %>' ProviderName='<%$ ConnectionStrings:Inventory_dbConnectionString9.ProviderName %>' SelectCommand="SELECT * FROM [addbrand]"></asp:SqlDataSource>
         </form>
		<!-- /product list -->
	</div>
</div>
		
   
			<!-- user registration form starts here-->


		<!-- /Main Wrapper -->
	
	<!-- jQuery -->
	<script src="assets/js/jquery-3.6.0.min.js"></script>

	<!-- Feather Icon JS -->
	<script src="assets/js/feather.min.js"></script>

	<!-- Slimscroll JS -->
	<script src="assets/js/jquery.slimscroll.min.js"></script>

	<!-- Datatable JS -->
	<script src="assets/js/jquery.dataTables.min.js"></script>
	<script src="assets/js/dataTables.bootstrap4.min.js"></script>
	
	<!-- Bootstrap Core JS -->
	<script src="assets/js/bootstrap.bundle.min.js"></script>

	<!-- Chart JS -->
	<script src="assets/plugins/apexchart/apexcharts.min.js"></script>
	<script src="assets/plugins/apexchart/chart-data.js"></script>
	
	<!-- Custom JS -->
	<script src="assets/js/script.js"></script>
</body>
</html>
