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

Write-Host -f Green "Desinstalando paquete de definicion de objetos"
Write-Host -f Green "Por favor espere" -NoNewline
Uninstall-SPSolution -Identity "IO.Website.ObjectDefinition.wsp" -Confirm:$false -ErrorAction SilentlyContinue
$solution = Get-SPSolution -Identity "IO.Website.ObjectDefinition.wsp" -ErrorAction SilentlyContinue

if($solution -ne $null){
    while ($solution.JobExists -eq $true) {
        Write-Host '.' -NoNewline
        sleep -Seconds:1
    }
    Write-Host ""
    Write-Host -f Green "Eliminando paquete de definicion de objetos..." 
    Remove-SPSolution -Identity "IO.Website.ObjectDefinition.wsp" -Confirm:$false
    Write-Host -f Green "Paquete eliminado"
}else
{
    Write-Host ""
    Write-Host -f Green "El paquete de definicion de objetos no se encuentra instalado"
}

Write-Host -f Green "Instalando paquete de definicion de objetos"
Add-SPSolution $ScriptPath"Packages\IO.Website.ObjectDefinition.wsp" -ErrorAction SilentlyContinue

Write-Host -f Green "Desinstalando paquete de definicion de objetos de carrousel"
Write-Host -f Green "Por favor espere" -NoNewline
Uninstall-SPSolution -Identity "IO.Website.ObjectDefinition.Sliders.wsp" -Confirm:$false -ErrorAction SilentlyContinue
$solution = Get-SPSolution -Identity "IO.Website.ObjectDefinition.Sliders.wsp" -ErrorAction SilentlyContinue

if($solution -ne $null){
    while ($solution.JobExists -eq $true) {
        Write-Host '.' -NoNewline
        sleep -Seconds:1
    }
    Write-Host ""
    Write-Host -f Green "Eliminando paquete de definicion de objetos carrousel..." 
    Remove-SPSolution -Identity "IO.Website.ObjectDefinition.Sliders.wsp" -Confirm:$false
    Write-Host -f Green "Paquete eliminado"
}else
{
    Write-Host ""
    Write-Host -f Green "El paquete de definicion de objetos carrousel no se encuentra instalado"
}

Write-Host -f Green "Instalando paquete de definicion de objetos carrousel"
Add-SPSolution $ScriptPath"Packages\IO.Website.ObjectDefinition.Sliders.wsp" -ErrorAction SilentlyContinue

Write-Host -f Green "Desinstalando paquete de servicios"
Write-Host -f Green "Por favor espere" -NoNewline
Uninstall-SPSolution -Identity "IO.Website.Services.wsp" -Confirm:$false -ErrorAction SilentlyContinue
$solution = Get-SPSolution -Identity "IO.Website.Services.wsp" -ErrorAction SilentlyContinue

if($solution -ne $null){
    while ($solution.JobExists -eq $true) {
        Write-Host '.' -NoNewline
        sleep -Seconds:1
    }
    Write-Host ""
    Write-Host -f Green "Eliminando paquete de servicios..." 
    Remove-SPSolution -Identity "IO.Website.Services.wsp" -Confirm:$false
    Write-Host -f Green "Paquete eliminado"
}else
{
    Write-Host ""
    Write-Host -f Green "El paquete de servicios no se encuentra instalado"
}

Write-Host -f Green "Instalando paquete de servicios"
Add-SPSolution $ScriptPath"Packages\IO.Website.Services.wsp" -ErrorAction SilentlyContinue

Write-Host -f Green "Desinstalando paquete de elementos web"
Write-Host -f Green "Por favor espere" -NoNewline
Uninstall-SPSolution -Identity "IO.Website.UI.wsp" -Confirm:$false -ErrorAction SilentlyContinue
$solution = Get-SPSolution -Identity "IO.Website.UI.wsp" -ErrorAction SilentlyContinue

if($solution -ne $null){
    while ($solution.JobExists -eq $true) {
        Write-Host '.' -NoNewline
        sleep -Seconds:1
    }
    Write-Host ""
    Write-Host -f Green "Eliminando paquete de elementos web..." 
    Remove-SPSolution -Identity "IO.Website.UI.wsp" -Confirm:$false
    Write-Host -f Green "Paquete eliminado"
}else
{
    Write-Host ""
    Write-Host -f Green "El paquete de paquete de elementos web"
}

Write-Host -f Green "Instalando paquete de servicios"
Add-SPSolution $ScriptPath"Packages\IO.Website.UI.wsp" -ErrorAction SilentlyContinue

$portal = Get-SPWeb($portalUrl) -ErrorAction SilentlyContinue

if($portal -ne $null)
{
    Write-Host -f Green "Eliminado portal de IO"
    Remove-SPSite -Identity $portalUrl -Confirm:$false
    Write-Host -f Green "Sitio d eliminado"
}

Write-Host -f Yellow "Creando portal de IO"

$colombiaLocale = [System.Globalization.CultureInfo]::GetCultureInfo("es-co")		
New-SPSite -Url $portalUrl -Name "IO Innovation Place" -OwnerAlias $ownerAlias -OwnerEmail $ownerEmail -Template 'BLANKINTERNETCONTAINER#0' -Language 3082
$portal = Get-SPWeb $portalUrl	
$portal.Locale = $colombiaLocale
$portal.Update()

Write-Host -f Green "Instalando capacidades de responsiveness..."

Add-SPUserSolution -LiteralPath $ScriptPath"Packages\RioLinx.SharePoint.Responsive.Server.wsp" -Site $portalUrl

Write-Host -f Green "Restaurando BackUp de produccion..."

Import-SPWeb -Identity $portalUrl -Path $ScriptPath"dump/io_web.cmp" -ActivateSolutions -Force -UpdateVersions Overwrite