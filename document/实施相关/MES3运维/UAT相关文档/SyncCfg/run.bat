"c:\Program Files\FreeFileSync\FreeFileSync.exe"   d:\SyncCfg\IHANDUpdateFiles.ffs_batch
if errorlevel 1 (
  ::if return code is 1 or greater, something went wrong, add special treatment here
  echo Errors occurred during synchronization...
  ::pause
)

"c:\Program Files\FreeFileSync\FreeFileSync.exe"   d:\SyncCfg\MESServiceSync.ffs_batch
if errorlevel 1 (
  ::if return code is 1 or greater, something went wrong, add special treatment here
  echo Errors occurred during synchronization...
  ::pause
)

"c:\Program Files\FreeFileSync\FreeFileSync.exe"   d:\SyncCfg\MESReportSync.ffs_batch
if errorlevel 1 (
  ::if return code is 1 or greater, something went wrong, add special treatment here
  echo Errors occurred during synchronization...
  ::pause
)

"c:\Program Files\FreeFileSync\FreeFileSync.exe"   d:\SyncCfg\MESUpdateFiles.ffs_batch
if errorlevel 1 (
  ::if return code is 1 or greater, something went wrong, add special treatment here
  echo Errors occurred during synchronization...
  ::pause
)


del /F/S/Q    D:\UAT\IHANDUpdateFiles\*.fc
del /F/S/Q    D:\UAT\MESUpdateFiles\*.fc

sc stop YFPO.MES.MESUpdateServer
sc stop YFPO.MES.IHANDUpdateServer
sc start YFPO.MES.MESUpdateServer
sc start YFPO.MES.IHANDUpdateServer


