$snapin = Get-PSSnapin | Where-Object {$_.Name -eq 'Microsoft.SharePoint.Powershell'}
if ($snapin -eq $null)
{
	 Write-Host "Cargando snap in de Sharepoint"
	 Add-PSSnapin "Microsoft.SharePoint.Powershell"
}

$ScriptPath = "C:\DEV\IO.Website\Powershell\"
$ownerAlias = 'kdev\sp_admin'
$ownerEmail = 'sp_admin@msn.com'
$portalUrl = 'http://portal.kdev.local'
$webapplicationUrl = "http://portal.kdev.local"

$webApplication = Get-SPWebApplication $webapplicationUrl



Write-Host -f Yellow "Creando portal de IO"

$colombiaLocale = [System.Globalization.CultureInfo]::GetCultureInfo("es-co")		
New-SPSite -Url $portalUrl -Name "IO Innovation Place" -OwnerAlias $ownerAlias -OwnerEmail $ownerEmail -Template 'BLANKINTERNETCONTAINER#0' -Language 3082
$portal = Get-SPWeb $portalUrl	
$portal.Locale = $colombiaLocale
$portal.Update()

Write-Host -f Green "Instalando capacidades de responsiveness..."

Add-SPUserSolution -LiteralPath $ScriptPath"Packages\RioLinx.SharePoint.Responsive.Server.wsp" -Site $portalUrl
