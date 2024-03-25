 ProductWidth = 450,
                        ProductHight = 750,
                        ProductSize = 450,
                        ProductWeight = 3.5f,
                        PackageWidth = 500,
                        PackageSize = 555,
                        PackageHight  = 1850,
                        PackagePices = 24,
                        CubicMeter = 1.205f,
                        Tir = 2160,
                        Container = 1850,
                        Coordinate = "F15"






açýlabilir liste (arama kutulu)
*****************************
javascript kodu
 $(document).ready(function () {
      $('select').selectize({
          sortField: 'text'
      });
  });
******************************
HTML kodu
<select id="select-state" placeholder="Pick a state...">
    <option value="">Select a state...</option>
    <option value="AL">Alabama</option>
    <option value="AK">Alaska</option>
    <option value="AZ">Arizona</option>
    <option value="AR">Arkansas</option>
    <option value="CA">California</option>
    <option value="CO">Colorado</option>
    <option value="CT">Connecticut</option>
    <option value="DE">Delaware</option>
    <option value="DC">District of Columbia</option>
    <option value="FL">Florida</option>
    <option value="GA">Georgia</option>
    <option value="HI">Hawaii</option>
    <option value="ID">Idaho</option>
    <option value="IL">Illinois</option>
    <option value="IN">Indiana</option>
  </select>


///////////////////////////////////////////////
Data Source=sql.bsite.net\MSSQL2016;Initial Catalog=abdurrahman4498_;User ID=abdurrahman4498_;Password=********;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False