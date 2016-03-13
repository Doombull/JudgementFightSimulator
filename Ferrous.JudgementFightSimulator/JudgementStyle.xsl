<?xml version="1.0"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/Results">
	<html>
	<head>
		<style type="text/css">
			table {
				padding: 50px;
			}
			table td {
				padding: 3px;
			}
			td.RowHeading {
				width: 250px;	
			}
			td.ColumnHeading {
				text-align: right;
				width: 55px;	
			}
			td.Result {
				text-align: right;
			}
			td.HighDamage {
				border: 1px Solid DarkRed;	
				background-color: Red;
			}
			td.MidDamage {
				border: 1px Solid Goldenrod;	
				background-color: Gold;
			}
			td.LowDamage {
				border: 1px Solid Goldenrod;
			}
		</style>
	</head>
	<body>
		<h2>Judgement Fight Simulator</h2>
		<p>Results as at <xsl:value-of select="@Date"/></p>
		<p>
			Attackers are on the vertical axis, targets are horizontal. Value is the expected percentage of the targets health that the attacker
			will inflict in ideal circumstances, including using fate point abilities.
		</p>
     
		<table cellspacing="2">
			<tr>
				<td></td>
				<xsl:for-each select="Character[1]/Result">
					<td class="ColumnHeading">
						<xsl:value-of select="substring-before(@Name, ' ')"/>
					</td>
				</xsl:for-each>
			</tr>
			<xsl:for-each select="Character">
				<tr>
					<td class="RowHeading">
						<xsl:value-of select="@Name"/>
					</td>
					<xsl:for-each select="Result">
						<td class="Result">
							<xsl:attribute name="class">
								Result
								<xsl:choose>
									<xsl:when test=". > 90">
										HighDamage
									</xsl:when>
									<xsl:when test=". > 66">
										MidDamage
									</xsl:when>
									<xsl:when test=". > 50">
										LowDamage
									</xsl:when>
								</xsl:choose>
							</xsl:attribute>
							<xsl:value-of select="."/>
						</td>
					</xsl:for-each>
				</tr>
			</xsl:for-each>
		</table>
	</body>
	</html>
</xsl:template>

</xsl:stylesheet> 