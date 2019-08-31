# LogNinja

Consolidates text log files, XML files, database tables and CSV files into a single master log.

Includes a web application that monitors the master log file and provides a live feed.

Use the configuration file to define your sources and how their entries are formatted in the master log file, like in the annotated example below:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<sources>
  
  <!--Location of consolidated Master Log file-->
  <masterLog>c:\Temp\MasterLog\MasterLog.log</masterLog>
  
  <!--Make a logSource entry for each source you want to monitor
      An example of each type of source follows-->
  
  <logSource>
    <!--Text log file - a comma separated text log file-->
    <type>txt</type>
    
    <!--location of log file to be monitired-->
    <location>C:\Temp\logs\app.log</location>
    
    <!--The format that you want each log entry to appear in the consoltaed Master Log file.
        Follows the convention of String.Format() after the source entry is split into separate fields-->
    <formatString>{0:yyyy-MM-dd HH:mm:ss.fff}, C:\Temp\logs\app.log, {1}, {2}</formatString>
  </logSource>
  
  <logSource>
    <!--Database table source-->
    <type>dbTable</type>
    
    <!--Source database connection string-->
    <connStr>server=localhost\SQLExpress;database=Portal;integrated security=true</connStr>
    
    <!--SQL query for extracting log entry data-->
    <query>SELECT * FROM Documents WHERE DateModified > @DateModified ORDER BY DateModified</query>

    <!--The format that you want each log entry to appear in the consoltaed Master Log file.
        Follows the convention of String.Format() after the source entry is split into separate columns-->
    <formatString>{7:yyyy-MM-dd HH:mm:ss.fff}, DB:Portal, {4}, '{1}' last changed by user '{8}'</formatString>
    
    <!--Identify which column name corresponds to timestamp-->
    <timeStamp>DateModified</timeStamp>
    
    <!--Identify which column error details are extracted from-->
    <errorColumn>Error</errorColumn>
    
    <!--Frequency (in millseconds) the source database is checked for updates-->
    <pollingInterval>2000</pollingInterval>
  </logSource>
  
  <logSource>
    <!--XML file-->
    <type>xml</type>
    
    <!--Location of XML file to be monitored-->
    <location>C:\Temp\xml\log.xml</location>

    <!--The format that you want each log entry to appear in the consoltaed Master Log file.
        Follows the convention of String.Format() after the child tags under groupTag are split into separate fields-->
    <formatString>{4:yyyy-MM-dd HH:mm:ss.fff}, C:\Temp\xml\log.xml, {3}, {1} | {2}</formatString>
    
    <!--Identify the name of the parent tag of each log entry-->
    <groupTag>action</groupTag>
    
    <!--Identify the tag that corresponds to timestamp-->
    <timeStampTag>timestamp</timeStampTag>

    <!--Frequency (in millseconds) the source XML file is checked for updates-->
    <pollingInterval>2000</pollingInterval>
  </logSource>
  
  
  <logSource>
    <!--CSV (spreadsheet)-->
    <type>csv</type>

    <!--Location of CSV file to be monitored-->
    <location>C:\Temp\csv\payments.csv</location>

    <!--The format that you want each log entry to appear in the consoltaed Master Log file.
        Follows the convention of String.Format() after the row is split into separate fields
        NOTE: Timestamp is inserted as element zero, so the remaining tags are defined as 1 based rather than zero based-->
    <formatString>{0:yyyy-MM-dd HH:mm:ss.fff}, C:\Temp\csv\payments.csv, {6}, Item no:{1} Description:{2} Cost: {3} Paid: {4} Due Date: {5} Notes: {7}</formatString>
    
    <!--Ignore first (title) row?-->
    <ignoreTitleRow>yes</ignoreTitleRow>
  </logSource>
</sources>

```
