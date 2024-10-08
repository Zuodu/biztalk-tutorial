<?xml version="1.0" encoding="UTF-16"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:var="http://schemas.microsoft.com/BizTalk/2003/var" exclude-result-prefixes="msxsl var s1 s0 userCSharp" version="1.0" xmlns:s0="http://Formation.Schema.ClientSAP" xmlns:s1="http://Formation.Schema.OrderSAP" xmlns:ns0="http://Formation.Schema.OrderPivot" xmlns:userCSharp="http://schemas.microsoft.com/BizTalk/2003/userCSharp">
  <xsl:output omit-xml-declaration="yes" method="xml" version="1.0" />
  <xsl:template match="/">
    <xsl:apply-templates select="/s1:Order" />
  </xsl:template>
  <xsl:template match="/s1:Order">
    <ns0:OrderPivot>
      <PivotId>
        <xsl:value-of select="OrderId/text()" />
      </PivotId>
      <xsl:variable name="var:v1" select="userCSharp:InitCumulativeSum(0)" />
      <xsl:for-each select="/s1:Order/Amounts/Amount">
        <xsl:variable name="var:v2" select="userCSharp:AddToCumulativeSum(0,string(./text()),&quot;1000&quot;)" />
      </xsl:for-each>
      <xsl:variable name="var:v3" select="userCSharp:GetCumulativeSum(0)" />
      <xsl:variable name="var:v4" select="userCSharp:LogicalGte(string($var:v3) , &quot;50&quot;)" />
      <xsl:variable name="var:v5" select="userCSharp:LogicalNot(string($var:v4))" />
      <xsl:if test="string($var:v5)='true'">
        <xsl:variable name="var:v6" select="userCSharp:InitCumulativeSum(0)" />
        <xsl:for-each select="/s1:Order/Amounts/Amount">
          <xsl:variable name="var:v7" select="userCSharp:AddToCumulativeSum(0,string(./text()),&quot;1000&quot;)" />
        </xsl:for-each>
        <xsl:variable name="var:v8" select="userCSharp:GetCumulativeSum(0)" />
        <Quantity>
          <xsl:value-of select="$var:v8" />
        </Quantity>
      </xsl:if>
      <xsl:if test="string($var:v4)='true'">
        <xsl:variable name="var:v9" select="userCSharp:InitCumulativeSum(0)" />
        <xsl:for-each select="/s1:Order/Amounts/Amount">
          <xsl:variable name="var:v10" select="userCSharp:AddToCumulativeSum(0,string(./text()),&quot;1000&quot;)" />
        </xsl:for-each>
        <xsl:variable name="var:v11" select="userCSharp:GetCumulativeSum(0)" />
        <xsl:variable name="var:v12" select="userCSharp:MyConcat(string($var:v11))" />
        <Quantity>
          <xsl:value-of select="$var:v12" />
        </Quantity>
      </xsl:if>
      <ClientName>
        <xsl:value-of select="s0:Client/SurName/text()" />
      </ClientName>
    </ns0:OrderPivot>
  </xsl:template>
  <msxsl:script language="C#" implements-prefix="userCSharp"><![CDATA[

public double MyConcat(string input)
{
    double amount;
	if (double.TryParse(input, out amount)){
		return amount * 0.9;
	}
	else{
	throw new ArgumentException("Input is not a valid number.");
	}
}


public bool LogicalGte(string val1, string val2)
{
	bool ret = false;
	double d1 = 0;
	double d2 = 0;
	if (IsNumeric(val1, ref d1) && IsNumeric(val2, ref d2))
	{
		ret = d1 >= d2;
	}
	else
	{
		ret = String.Compare(val1, val2, StringComparison.Ordinal) >= 0;
	}
	return ret;
}


public bool LogicalNot(string val)
{
	return !ValToBool(val);
}


public string InitCumulativeSum(int index)
{
	if (index >= 0)
	{
		if (index >= myCumulativeSumArray.Count)
		{
			int i = myCumulativeSumArray.Count;
			for (; i<=index; i++)
			{
				myCumulativeSumArray.Add("");
			}
		}
		else
		{
			myCumulativeSumArray[index] = "";
		}
	}
	return "";
}

public System.Collections.ArrayList myCumulativeSumArray = new System.Collections.ArrayList();

public string AddToCumulativeSum(int index, string val, string notused)
{
	if (index < 0 || index >= myCumulativeSumArray.Count)
	{
		return "";
    }
	double d = 0;
	if (IsNumeric(val, ref d))
	{
		if (myCumulativeSumArray[index] == "")
		{
			myCumulativeSumArray[index] = d;
		}
		else
		{
			myCumulativeSumArray[index] = (double)(myCumulativeSumArray[index]) + d;
		}
	}
	return (myCumulativeSumArray[index] is double) ? ((double)myCumulativeSumArray[index]).ToString(System.Globalization.CultureInfo.InvariantCulture) : "";
}

public string GetCumulativeSum(int index)
{
	if (index < 0 || index >= myCumulativeSumArray.Count)
	{
		return "";
	}
	return (myCumulativeSumArray[index] is double) ? ((double)myCumulativeSumArray[index]).ToString(System.Globalization.CultureInfo.InvariantCulture) : "";
}

public bool IsNumeric(string val)
{
	if (val == null)
	{
		return false;
	}
	double d = 0;
	return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);
}

public bool IsNumeric(string val, ref double d)
{
	if (val == null)
	{
		return false;
	}
	return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);
}

public bool ValToBool(string val)
{
	if (val != null)
	{
		if (string.Compare(val, bool.TrueString, StringComparison.OrdinalIgnoreCase) == 0)
		{
			return true;
		}
		if (string.Compare(val, bool.FalseString, StringComparison.OrdinalIgnoreCase) == 0)
		{
			return false;
		}
		val = val.Trim();
		if (string.Compare(val, bool.TrueString, StringComparison.OrdinalIgnoreCase) == 0)
		{
			return true;
		}
		if (string.Compare(val, bool.FalseString, StringComparison.OrdinalIgnoreCase) == 0)
		{
			return false;
		}
		double d = 0;
		if (IsNumeric(val, ref d))
		{
			return (d > 0);
		}
	}
	return false;
}


]]></msxsl:script>
</xsl:stylesheet>