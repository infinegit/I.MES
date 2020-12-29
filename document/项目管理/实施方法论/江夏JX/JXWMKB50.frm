<?xml version="1.0" encoding="UTF-8"?>
<Form xmlVersion="20170720" releaseVersion="10.0.0">
<TableDataMap>
<TableData name="BondKB4" class="com.fr.data.impl.DBTableData">
<Parameters/>
<Attributes maxMemRowCount="-1"/>
<Connection class="com.fr.data.impl.NameDatabaseConnection">
<DatabaseName>
<![CDATA[江夏正式]]></DatabaseName>
</Connection>
<Query>
<![CDATA[SELECT top 100 InformationPoint,VinCode,LGS_JISPointInfo.PartNo,BriefDesc,LGS_JISPointInfo.CreateTime,BackColor FROM LGS_JISPointInfo with(nolock) LEFT JOIN V_MFG_Part_NOVer ON V_MFG_Part_NOVer.PartNo = LGS_JISPointInfo.PartNo WHERE InformationPoint=50 AND PullStatus=0 ORDER BY LivePointTime,id]]></Query>
<PageQuery>
<![CDATA[]]></PageQuery>
</TableData>
<TableData name="BondKB5" class="com.fr.data.impl.DBTableData">
<Parameters/>
<Attributes maxMemRowCount="-1"/>
<Connection class="com.fr.data.impl.NameDatabaseConnection">
<DatabaseName>
<![CDATA[江夏正式]]></DatabaseName>
</Connection>
<Query>
<![CDATA[SELECT top 100 InformationPoint,VinCode,LGS_JISPointInfo.PartNo,BriefDesc,LGS_JISPointInfo.CreateTime,BackColor FROM LGS_JISPointInfo with(nolock) LEFT JOIN V_MFG_Part_NOVer ON V_MFG_Part_NOVer.PartNo = LGS_JISPointInfo.PartNo WHERE InformationPoint=50 AND PullStatus in(4,5) AND VinCode<>'空挂具' AND VinCode<>'按零件' ORDER BY LivePointTime,id]]></Query>
<PageQuery>
<![CDATA[]]></PageQuery>
</TableData>
</TableDataMap>
<FormMobileAttr>
<FormMobileAttr refresh="false" isUseHTML="false" isMobileOnly="false" isAdaptivePropertyAutoMatch="false" appearRefresh="false" promptWhenLeaveWithoutSubmit="false"/>
</FormMobileAttr>
<Parameters/>
<Layout class="com.fr.form.ui.container.WBorderLayout">
<WidgetName name="form"/>
<WidgetAttr description="">
<PrivilegeControl/>
</WidgetAttr>
<Margin top="0" left="0" bottom="0" right="0"/>
<Border>
<border style="0" color="-723724" borderRadius="0" type="0" borderStyle="0"/>
<WidgetTitle>
<O>
<![CDATA[新建标题]]></O>
<FRFont name="SimSun" style="0" size="72"/>
<Position pos="0"/>
</WidgetTitle>
<Alpha alpha="1.0"/>
</Border>
<LCAttr vgap="0" hgap="0" compInterval="0"/>
<Center class="com.fr.form.ui.container.WFitLayout">
<Listener event="afterinit">
<JavaScript class="com.fr.js.JavaScriptImpl">
<Parameters/>
<Content>
<![CDATA[setTimeout("globalForm.loadContentPane();",30000);]]></Content>
</JavaScript>
</Listener>
<WidgetName name="body"/>
<WidgetAttr description="">
<PrivilegeControl/>
</WidgetAttr>
<Margin top="0" left="0" bottom="0" right="0"/>
<Border>
<border style="0" color="-723724" borderRadius="0" type="0" borderStyle="0"/>
<WidgetTitle>
<O>
<![CDATA[新建标题]]></O>
<FRFont name="SimSun" style="0" size="72"/>
<Position pos="0"/>
</WidgetTitle>
<Alpha alpha="1.0"/>
</Border>
<LCAttr vgap="0" hgap="0" compInterval="0"/>
<Widget class="com.fr.form.ui.container.WAbsoluteLayout$BoundsWidget">
<InnerWidget class="com.fr.form.ui.container.WTitleLayout">
<WidgetName name="report0"/>
<WidgetAttr description="">
<PrivilegeControl/>
</WidgetAttr>
<Margin top="0" left="0" bottom="0" right="0"/>
<Border>
<border style="0" color="-723724" borderRadius="0" type="0" borderStyle="0"/>
<WidgetTitle>
<O>
<![CDATA[新建标题]]></O>
<FRFont name="SimSun" style="0" size="72"/>
<Position pos="0"/>
</WidgetTitle>
<Alpha alpha="1.0"/>
</Border>
<LCAttr vgap="0" hgap="0" compInterval="0"/>
<Widget class="com.fr.form.ui.container.WAbsoluteLayout$BoundsWidget">
<InnerWidget class="com.fr.form.ui.ElementCaseEditor">
<WidgetName name="report0"/>
<WidgetAttr description="">
<PrivilegeControl/>
</WidgetAttr>
<Margin top="0" left="0" bottom="0" right="0"/>
<Border>
<border style="0" color="-723724" borderRadius="0" type="0" borderStyle="0"/>
<WidgetTitle>
<O>
<![CDATA[新建标题]]></O>
<FRFont name="SimSun" style="0" size="72"/>
<Position pos="0"/>
</WidgetTitle>
<Alpha alpha="1.0"/>
</Border>
<FormElementCase>
<ReportPageAttr>
<HR/>
<FR/>
<HC/>
<FC/>
</ReportPageAttr>
<ColumnPrivilegeControl/>
<RowPrivilegeControl/>
<RowHeight defaultValue="723900">
<![CDATA[1638300,1828800,2880000,723900,723900,723900,723900,723900,723900,723900,723900]]></RowHeight>
<ColumnWidth defaultValue="2743200">
<![CDATA[647700,4032000,5184000,10080000,7200000,0,2743200,2743200,2743200,2743200,2743200]]></ColumnWidth>
<CellElementList>
<C c="0" r="0">
<O>
<![CDATA[ ]]></O>
<PrivilegeControl/>
<Expand/>
</C>
<C c="1" r="0" cs="4" s="0">
<O>
<![CDATA[50点已拉动]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand leftParentDefault="false" upParentDefault="false"/>
</C>
<C c="1" r="1" s="1">
<O>
<![CDATA[车号]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand/>
</C>
<C c="2" r="1" s="1">
<O>
<![CDATA[零件号]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand/>
</C>
<C c="3" r="1" s="1">
<O>
<![CDATA[描述]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand/>
</C>
<C c="4" r="1" s="1">
<O>
<![CDATA[过点时间]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand/>
</C>
<C c="1" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="BondKB5" columnName="VinCode"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand dir="0" leftParentDefault="false"/>
</C>
<C c="2" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="BondKB5" columnName="PartNo"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand dir="0"/>
</C>
<C c="3" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="BondKB5" columnName="BriefDesc"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand dir="0"/>
</C>
<C c="4" r="2" s="3">
<O t="DSColumn">
<Attributes dsName="BondKB5" columnName="CreateTime"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand dir="0"/>
</C>
<C c="5" r="2">
<O t="DSColumn">
<Attributes dsName="BondKB5" columnName="BackColor"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<HighlightList>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Red]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[Red]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-65536"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[blue]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[blue]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-16776961"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Gray]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[Gray]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-4144960"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[White]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[White]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-16777216"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[LightBlue]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[LightBlue]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-6710785"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-16777216"/>
</HighlightAction>
</Highlight>
</HighlightList>
<Expand dir="0"/>
</C>
</CellElementList>
<ReportAttrSet>
<ReportSettings headerHeight="0" footerHeight="0">
<PaperSetting/>
</ReportSettings>
</ReportAttrSet>
</FormElementCase>
<StyleList>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="200" foreground="-1"/>
<Background name="ColorBackground" color="-16777088"/>
<Border>
<Bottom style="1" color="-13382452"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="184"/>
<Background name="NullBackground"/>
<Border>
<Top style="1" color="-13382452"/>
<Bottom style="1" color="-13382452"/>
<Left style="1" color="-13382452"/>
<Right style="1" color="-13382452"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="176"/>
<Background name="NullBackground"/>
<Border>
<Top style="1" color="-13382452"/>
<Bottom style="1" color="-13382452"/>
<Left style="1" color="-13382452"/>
<Right style="1" color="-13382452"/>
</Border>
</Style>
<Style horizontal_alignment="2" imageLayout="1">
<FRFont name="SimSun" style="1" size="176"/>
<Background name="NullBackground"/>
<Border>
<Top style="1" color="-13382452"/>
<Bottom style="1" color="-13382452"/>
<Left style="1" color="-13382452"/>
<Right style="1" color="-13382452"/>
</Border>
</Style>
</StyleList>
<heightRestrict heightrestrict="false"/>
<heightPercent heightpercent="0.75"/>
<IM>
<![CDATA[h0X?J;sC`7R*:)7U8(6ad8<l=.(t:a^n;lZ"dCW;"=_bBKLA,B7]A`8I&7I+\M+DQAL_(.A5r
p.lUa3=#Oq<e<j9DO@IEm5tRI?[C4m0BR!B^27C[G,NCTZL+GIVYJhF:t,r!!-$+E?JHeO]Ac
!3s#C)19sYSGfJmfNV*:%T&>Ei`T`bk=cu5=W,(%/:XV\P=B':uYoH`5hcmk+Jas/6qkoM;]A
8f5i:.)=`#OZba4Q^^*X'@b2I]AM6@9B6Eh]A?bZhJZB6t>HHWnYl%T>'E0DI+&_CMMog[%\<h
4A\kY,LYg_l`Q0Umd<koFaD%i`u?;nMAV^m&ANX_XK(Y/W1r0>0KauunJ-tNp!h*"bX6>l-n
8T"'''<3rP2DA-p;@Xj.ah7diA0h2I'SqWD@4O<>4Q<]A_h:ULM1]A<58I$2o7-a'n2\Tgunk/
0>\[*4c2CEm2oq%+aiS\_VmSo:XU0b5]AP0gW/EIt0X\/H88u*+&A<=)q<i4YH$)9&0=5`WX3
Kg=_T1;_q%.Gr*`(RXKHk0@(n#6!m5i^9s/9E<+3RTem":9;NV\.uTooJQnij.SYBu8QX\YA
%Pjd%.=Q<?F^YM-G'<NV>Babm"Ok1?hf_4UWW/^bH#hT=%P,HK.i:Rm?pLGSf`@Y*@SQY#eJ
l)[V=Hm^Eb[cf^NS>\T+O`ABq&E__@@XMjB0di'*HFE+OHkH2?t)4XN>dU_IZL:)'cX+2HPN
Ju6%+<_M7Z5IE4'Qq>l.,c1Se@,9?LUcIa7H9+CR_NP\WgD>5+4q:B5hWq!JM)DCHFs:LL]Ad
l7&X7m(g.p5dG=#,uV&rCC.:5?)c<0K3\>,Nj\-!db=+]Ati8FbLj@V)rW3S:4bB=:ZrerL:/
cg'bX^lTsqKEPg=[6`6,9c@%iH\Z'G[nZ0H^c(b3;8U\#tNC:'63h$=#o9U5sd<"hK=W!VcL
us_EOPP&p0NBV^=k'iRkHuomTYU6uBk"+R"k_-Ak0cV)B/ui"'oMIHq4ZkeC^:ZsCKs29=]Ao
@B^K`RRs&H'd$)JdDX8iL.kCj^7SI^H"Pu@ipga7hS99fR94N(lJRDd`"8mr&I:YGr^i?qAC
4fp9geTf1HY'KFd7_q+JnsfGi&tb`$3sT-ZfR.PboVs^6;lE-Vp@8P^EV&E((W206'`#U[.l
4mCYHtq%-c9:@Tt&Wc,8D'h`n(<3!0-a'X83:-:.l3@=LN_+/(0#hnI)jnWC(ub1Ksde<9&c
Y*&EJ4QKm>d9`11bHk%\S<>_BPC#Q8iS%n1]A<QM_#$&$f37M#[Xr7p1poIFeI;+,scXL%EJZ
*9-QD[i7<?+*<:6A5"L5(]A8im*j=U**uKjpDh6SPD\5W5>H7D\aP.ZouoQ]Aa?>iV9t>/VM@]A
g]A1"K?GN>FZ.Qa.#=!2Nd7lhjgM.h!k0^7I*;oYj"*o\-=s8Q?C7[UN4i\D2n-6u?kS^<>4)
cN$e+;FmT47@m\Pp$$OfMe85!FI9UFouHB*7Jq;P"d\Lf^i1[c`fNK/"dBG(k9EA.JSS<>Ys
0CSee)Xa#:m@"lfbgm((K#GBZ;meqFKrIGp/&W%[r5d5"e#k-BgD[*[ltm>Z=K;8ig`*_(s^
t:L2C-GEQdM%I\hU4\H;kNPNkGiqV&SR>k7#E=\F/ODCm[A+Is:.<[><21HYrLIkabL%G&%!
_*k,k*R95ii[aM/fp^j_(,jZo\qd/'+Uk?bfA@1OZ#3<bE@bn43$/>,%+PtKY`ct\+LH6Nil
GsAiLQd5<..YO**X;A>R"YeEbpZr:#&n5H'[VU+Z604.E?fmaTG^e1]A;#/CRBLY)g'%8F*TF
rTG%)6b2_b,TtPH^?nS;C9`^@kSBWX(Xtc:Idj'01af5]ArDcMp.5X"/hKJ878pkR'g[N0flA
$(]AKE[Xhq7^Ws:UaYu.!=9qLjI?e`GLBc(mR?inr[J:eV/:4d?Q+Dai[=Q(luS8l$[Or?c7b
f]AWP1r^l$^7<$8)]A"S(SZ&YLhS`SQYKe;B274&S<iFj$IOg[lC#ZV3!T8o\e1'>$MGr?sm!P
ZVp9!]AfP7jTO,Sn<V*D5=='YX+SXFircsXF:#f-`Ld4%*Yo%i4%eY'MK3="eS)f;,K6--d!J
9,egd=NdN2_tPV>#LUNhl,r.r?_k,VPHC3ei*0aT'u]AJS>[h7YtPNX^/>YIS@sg?(G"a)R!=
FM39ZjM1!]A1>YO':]A>H3.aDA+`+s>50#^#RftM\5`[>j`<%FroA(B;u49P3I+gm\1I=#&(O,
PN=Ra4b6N6SXcjPkNO;&&P`B1/B=ES-U"DnY2PW<B9KFV5g@7V8RCnfT<.Kk]A2RRYD1UR^S.
EpXY1n(nlTTr7D4+TciS$#t!b?_Cm+'W&LUjg9-AcC0XfNb@N,93C>O%OLq`CqoQK*IBPHkY
4$pMrGTsUMTYQOmCG:N4QO'rR+&dkLDZC1'%`(_Xuco\1YGKdE[t(_h$1?pZr_odCjJN8ASG
W>OdjWdYF;/pj6G)R^9-qQjMDLmYYWD4XQ*Nfj_<P,B&I3<G^fTZ9T_kN$SPN"F^UnJBqd3h
9m/60gkLiQM77oIBuehM,i9TmPR/Ee;rQd]AI+%bVnqg<TrnOTJ>%Q$VH&MDuWk^!R<#Q/>%p
t/k9=?t0bF?W'idrs&_GjLlLOSW\j,`;mo;"51j'U(:^X[A>;H1=DIH@?u8A@Y>P\;C4eDkq
*[-N7VW>&&"18=mpbhfAe.FNLhfs?Xu+)tKUZE?A`eO@E46:37@nXGO'g`4-;SbNhe;=?"$G
8tlh23JDn\k-_UlJO(Tk,FXW=2Y(H.d$CX&t!l_XYJ#R4m9"\1?tGUK$(%#a"U'!QL/:X@;f
>>So7SNh"XlCDBm/DD#XO%VEFjAa6`Y`]Al.Ns'+ZN5r4c!ueQK<KCXX(@=BVj(]AING,KoC`q
p"Z-f90C;a`UYd6SS=MC2:C"=#JT9(PS=U88)3iZZD`]ATW@9Ks[ccB"]AcrUonNXcb1GDPAVm
d9N*X^ge8jkHS"ZCFDG%"gA0)[#Ja$.TN[tu*_*1lFa[,t.KU6loh`6aq(Y;I@Xmu?A4QbqB
[O`=2a*QYiO"q5]As+%gKOC+p=_9eXNLF-CMG+nNuhLD!hsK(9JM:oc2hEotjU]Anar#(V7PT8
2\OYkinC1o@`=mhVN4P(LV26]AqbNogj:uea5Tm+V1NS"+EE/$>jH;@Ys\h.V9>U_8Q+L=(Kk
Wf/+%BKT?]AgLV:+^Ydr95U_(R@"M)VcnQ[3<$FLCa[[3ID8<0SV\qkY]A`>;rH6EL`BRT@/0c
#*dlldRWl0rGn/oF&7PJE4a%Dg@a9fc@KO<gIu1/&WaF`@X=&UTUT7*!eRF'B62c!>^*[DJK
rpRh*"%7ZZTjk,C-tW2NH7#+&AnVo;.IbmI'uCg8&,#D%6558,MJkNntb%c3:d\s32drPFG.
6-`(6/-df01(ZFe)Wl@"FIPsrofmilR4%l*:pF7sWZVnD7r+?-0LCTjRP6'cb+G5i5#q=u[G
*ANKi[5CU"9EF0W@q;:#PoY&ZrtRI4l^c$`oO7LDKL[:kR5Z&iP7]AC&`CY\DP(KmZV2U0>'%
1.nc:L^,`OaSd.&\*_7>;T0mqpdKJ,W44X'RtjDG4sKI#&+6sP(!i(H+PZhAa!/'A0hn<*_B
:)]A51Ju)t`h4daR-H@WB7D+7fV`*9j4uJEj[H7o;?B/@lnc#K5q"^N$enJ5?[/u<-INQRIW>
DNOr*1*tAEIP[+hm]APBO5:p3.j51Y1T80]AW_B@U$C`c)ekdoa'")Xj)3skrV$`[?9,H"[9uA
,`)3d+.a\Ds`E]A!42X6aNnd@t[3kD"8UG2u>dQH<c!GSR\+*j.K]A&qq2;5J,D*cUk%Xe$-$;
5lM!\erEL?RS2J!Z(WN&%-ZJL3VHIVNj>Bo05<Z+[jQ:HupViI&s8fb1<eagEtf;oD[qt[FT
Z$"UVFX7cu9mF9FA^]A1&^+X(N@CS\7'f!5/8eG1$5W5!1\$J1R\h8KRm8a.ldYS4`h#;IrW(
iDZo&B+9l6j)%e+g[#gOE(lL=@fu-f'J7\@4:h\L5X).rC!"_$H>\q28B/'I5PT4P%%bgn_l
@-BFtg=4IAmM88@,'?<Y/'d>%j=`65M2uKA4aGql:_@4cuN_*\U\H'/jui'E/&MkE9H4mf5M
"Sg_#"&_+osN,,E#a)(KEQgEM<[&!QdS3qEshD"3Um_fh]A4_>$dK'mk,O%OMEQj(?h9ZU'&9
1jSe/_MY,S<SCIE\?l3d)\43h`(R$Bc$3U<[Ie/R);*.W&U!YC$:anh:dLU6+MTseh\n,QSX
peSgSmfi(-E-9dP!+Lh"##Z[YT_lkH;e$*H<i'P5eXF9GLf]AQ/Q@mpu.G<6M/4hiAC,JU[Tn
lamh7*jaIgPu%Kmd^K;@]AeU/pVD`GWe$O]A;]A3$[G22mI:3DurZd%N&UHX2q8ni7'"\N(\Z@]A
;iiUNglu[&Wtc2_a4n5`&)pCh\Le!q78)^0H*7B5t*Mjo_?TkV(%ae[$kMaM7uOQ(Jkai(BH
q<96mi5B,p$CO-I+GGtombs!PRh`j#o2,`:>[*<R#!j0+<lIJMWlQ-&0O>qMTS1pR`eDA[pY
CtDf,-_!:2G+h/UUVK>b&clYlP)MsMOe=QhS_#rQp0)&7+#^so6lCHX0mo_d#lJI']A]A0RZ^1
pWA5]AV%E(tf^N/1MkY8.ZTmGqER5"qI]AqlXEkmb-8#-'Z[<FL@C&]AI7o;`/"mG9l,)]Aq6YIf
AasGeP;934eJk,L"cW<(X\rAX_R,[+IUMh\q>9$c3lY)Bhk1X,Sl.1Q@_4"d%2WZ';K]A49/t
@]A,^mcTN;FS^jR_rbGClV*'nhtA!P=OHW*21d^U[dsAJJ$r.\Xd+YB+n4$&usKH-Vs\4ltT@
!"RKr7.maEU3fPl97&H:pZ4QPDd2,SqbimAAhbf86!VNfBQb8bQmMh/]AeeXYd"K>^lU`afL#
I/DkVSHfE36[l)1UKKE`dj.9(T=lO6(4/jTJH<Xm;V6I3L@o3(9t/sMt.6QPHP`@)c!iqB=;
]Aarr'/Eq=7RKV>[XbR>WO.md]AT2lQlh&#_OFe39[tKomtntbo<ir4!b.`d!Gc=6_MnP9S.dr
6HMLeinj(DB4`SJ*OBS;?).?DSKMCP'C$qP1'VXiqY7dP!1Ib8J;.P3)<RcZ_@=DeG_-BQX@
LBW.F81h%cF3o%\ro`Wi>H<N;M>kjK/`iPqfk]A8l''sh+Q@f@Ci4%'sZtZ8t=Iha3afTN$oF
'9TEGedat!Q1qX25&\26\KaT>rQ(#)/]AQZP;BW6h49'6'dOKfg.-;sFZ*j/bKl#6<PX@FV-1
Q#Dfp:]A"fCKkm@:P'.7oMC/K,X89,Pbp&dTh]A%0B<"VSIa_,,maPMq@XJ4%03\q!X7"6%W;#
q*nb6]AaCN2>?7W5(.Gk;)OY8@rtO7I76hp%jB+u^2DF7;bTT52&V)VVT@Wn"Tmi+<ZULGGfq
%b[Ps#*<q=p=_nr<h!2ELr:SXpBO!lr>gCs`g9(*cFTk?SO\mKrf:>ErV,hA9qu<TAckPQrW
`tW=#?T)gkp[+Q%VH;..tl%/6nVCdnI8JQ[qYL!9Rbq"?r&c^Z;J:RhuQ8<^-Eb('$;*b%%5
He")j#UsGh'Z]A@1m,k&nLknVo7d;5<5SQ_()(ed^Vn?kfW2cg;c.u'i.]AqYaq.S=5c6t6<Af
qT?27,ft]Aq`E%dQ"^NG,$3Y&\LqF'?"%n'f1+Q?^pUL,UqCUu>b@?6T5AS5_WHPgLuW[[gu?
Wfb86Bfe9g=]AeH?mNBK;1!DL[XBPUKK^I%rDB7]AklkZ6QqkcfCM]Ad2Sak47e[GA<;[Z`MOFG
Mu/;=pR^pu`&`k#0FoaI<en5i-]A;.mJhl8C]AH&?qduf7V?c\I//[1U`bk]Aru3.HY&g:5oF8J
-f[#]AbgA*coRVCYJ;-+Y9@8BtG<Xk*DVRJKAr;NVc>*dnJY1LA@dg-jAd*q)W=4A/*.oJk^C
L*+)/3FXj#^Gs.KnCMoJem,u=/AU"WL??h&d@OL?NnnoE7dhdsQ!rt`r(Ss/p2O/Akp&Z1-;
3baLDY2.QN$KA:q`qQEq.#?SBs$J#LB?:P9GdM)U(l#U`b'_VW-(H_I5f$;?3IiEIG87F1Pn
$9PqD$W^L/oSlH$Yta8N,WpMi7Vp^.Wj/X[lpK.+.KD)jnJB>NoG/Rg$cob-XGp+]Ah4rXe;K
0[I'^RG[pq]A%L[=p@_n7qJ#AkPDKulpi@[T*P#eO'P.YL;?)R[4*O@!;lH0=GlA4*V#SH&!M
k@e->C4MAf'b^Be#Fp7,+\OlMj4@C[k8T;dmc^UdOVMY4ZZL*)f3d<pAl=O!Ouu3$7P2*Q"n
ZTRb:[WurSQ?&5M(%?i![4Aag\6H.^eiJGQZVl4"B$"[j0<aB0gUJ[^=2S4]AhlE"qV4b:'nM
tBQU\?WDl&P%P&2]AaD'HV^pE%G_`ubR@KIqrf"7pV-M)(Np8t-G()#X6St@m1/)QKZ_^n\]Aa
SY[Gi7g":W3H'F`#B)@?s\0,R[5$gRB.e.5,Q)!'P+Nl>ajg%Z@a*_a`uNIT4YcXduA_Y;os
TJ]A,d'MFH1"%/RK''bs#[3jF5<2/dPV:U)2-f1CA]AV;.SD""W)\c^);XGTTWgDdb2q7C/'Tq
5@s.j-qN;2Ld4ZWq;CA[>;:Zn0?+e=]A)#`?pCRq`j-OD.BOGOqgf&)ol[%27RZ-Uf?LIc:XI
]A9ZR)Sc>A\ba@cB)CU+q[kVb6UrC?&49?=-jm"6$0"BDaSn!XGIXs$geh;XnmV2B5Ln+hQP4
l1EJ1*H!/7[+5pKYS?FRc5P6Mf9_".Y0Q;F-,&32*d$6H9D-3.OqEHa@cim?!n(jM^5"O:Bd
Hp_nBO:D7L`fK+P'HD-qCm;&7l)<c4@NhIjS0NdZj6=KE!mj[$;pL=e9hHJI(X^<%A8rh+Nn
g";S_M6Z-q6]AC]A53BpD%GkR,&V#kD%r?N.=*<@^<<'hilb:2qQ:8iO6)n#Q;$%rc?L%8/hUQ
LW[7RmC8_Vtfchq&a]A"`fO;-Lkq*PGt4/V,;mQe"k#uM\c*Urr2)t_7?eu-1m*B1@Xi(UCr\
N:<d^oZQ-OZ+kZ!RA(Si-r:'/Kb<hF,i&'.`&)-Tb'qU\r2:c!.>6n]A0)!(4aIA^5Q&K\sro
=(G$mCge]A>o#KU"OOsEK`S)"I!$41$EDUp)]AVs:>a`3<:+(QH&oBlchnl4NLf-b:o\K1X>'Y
kn,4,^XNjd8KHcSS*!1gqrVdip&U!5o06qV:#E992>(Z$bd9"u6fbl+S#!R2lc%>_3:)"8Hp
Xu)*h2b1[]AGO<";CH-7dU1X]A?lb;l;;fYN+9elK,/hU2MCfF<r1=>cc.NU6:KqJ9El[I$1'b
>I/1'katD$t`!0`Z_:,oc^,:A1l5ohU'7.N%b><UC5QZX;jn.Ha-2#.%8>`?t@(.E2_qOJ66
+^bkIhhcQTm8rP5r?j`e(pVpsX`"+Xo^99L,"*=,@Q3ptu4.=n$F6Ctcc4@iSY2Wn)qNX.>[
@k".lmUub<ZsSGdOE_GVWKLOV$H\6jh<'AV*IlAT(KsjRcL#:)`j>t^sMk`^^[\QUb:2C1\p
S-TO3F]A!MPpt`oaC]ASI;=.eY6"la6"gBP[j=QX;-#1*nX%LD?N5N_!oSA5VO49Jgg!<;tWRN
SbV9?J8DDN/VH&"=D!G>6E+i]Ar:T3dG93$n-rLfuK)8CE=^L%oc'%="`i-X^ca?E?KD"$7Dt
7,f@U7k>NT)0(,.!Of_p^"k39nXR&S"V/6@lR!+Q`#u9D+*k%W1rFNWtKuqBaeXa^FI'4G:#
!2<k/iANu@/cc]AC90r^MFdkCA!Z0E0^DU$NI6(B[(HrcVV.<OW,;nNXRih3L$bfCH'\$$-U"
^:jXLs"ZA0Pciq[Vd"S9Ut1MF*up`mVqdp#4JQBh9ZT;ZrB2c.ErlWGfrbRlON)UpG[8s0H%
u7G6<6fC(mhPG?"=FQ80C*Nt!&j]AF[%fGP\`NWR8O:VVWA:6o$B__'T[1eY/7[i<dPbdl3.(
V<>g+X\MA$\[A8+S$r&cn)[ig2OW4:8G5]AgeEJ>U=K$iZiBRDH$&pN$-cbV2q5qG@Fg+@S)"
IBZVjN7n7amE[YfJbj/Y#lJHI*=]AOHURP4nl.9(=/,Z]A?q\?]ANKP!-AE*drXoBJ9u,1)$/mA
h-cGMIf63Q[LDL.<;qqmMkUHq1O8qA@Hi)_G#7idW<MF;4'&9DKE?&M&I[0F0(efeNIZb.0R
C1*S;b$HK1>3=@`d*!ZYnRn-DuA7s:C&VM,+DCtO8;ForEFeXGaR$K2UfjIOOYZ,D#/&Dl35
LN64\E^1IX'F<i6OWWCD,Qo$>_HWDoj3b[hFdqiI6OOQtY+!HqLnSEU$8<&+NYqZ@`&&">L6
7B@?l%R,nXT.H.fo%V[JT(kog@$flj5:3)e%tF6l88@bZXP]Ak)PpIb'jhWfX2V^6V>#*+f4m
DK0fZCp^f`K,qS2,9/l0G8^(FSu4VK'-+b_=$/4*jDU#&ZP,1em/K2lt<8W%&PS&YUJ3d6F!
Q5<^,f'[7Kh(IR&U<-O1i*ggc34!ujfgDgt:jg)e(CO72$$$A\LlcZsoo_KD@.MHQaTd'ra2
X@'#8^WG,-q1JMAtD!h]AW)iQ=CM$1V%iP4=5E3-i`Fdu.ltnc'HP]A47F2fbq3PSJJW05jLR]A
TcLO4l6f$M'p!0iMm2JdDZjMil/n@iU-&=FsK.Aq)%9l#Jc<PlhYAhKr!587t%D8@^S*C<O@
m%.b4(QT##R&0ZcHoHp\[47HYM+SolO.Opo5O3E[r'Oc>,)HL'$1C3>L7Y7lmTGtdDGG:(q@
[3igGjP!.GRJbAHDO*2:!kLqf=0;.Z&(SY)j&'p!E$pF\?IORL:MnqEom+gmB09!n*R<j`8]A
f<inlUOODD!Ps^m#.G3^#WK+$,G:ZcSCCkK]A#MBF&S91dqi\/#L"br#&G1">D#%_U#0@Gcg3
g-*u@S-0_-!eP'He_@t"m(D]A2p]ALf%q5Yf71a;1,rc*^"*PK;E*E2kaTnl=2<$&#^J&mTI!T
*l(HI)KXIsW@)T6rb"*VXS'c?)4h&6MR#l:ku`N6l8EO?.o;`Oq0&1^g6(7=.<97L/fhEaS:
71"[`!I-d<M.`]AT%28#>jd/6e>8DROgf0ZeSXQ%q7+7UiOF2hFcC7n46B.CEUV-@@aiYXsY-
48qmH<il8ntghPj4>p!uXHC^nh_WNirk,?q,FB4DgXc$jZ1W]A:,_W?KM8]A&cat;VGVJ>Jh[3
ua+dUo*UM7-j91,l5IIaL)2Fc3")BpI;B\?Pe`@]A41B"c@mtZFD$iPX?B'$9_`ZQ/37&RR'h
GVW]AT6`N;Q:6MW,^/o.-R(4)6'b(TU4m@7n]AGQS(^qml3KKd:QUgDX$YOX:HdgYepe]AGBI4e
%HT^e0*SHIN_7F6JaDa&a5iS14$$]A^Kt0:KL=X7mqLG<>Xk)<Mq]A[*MA;I]A?!8/W9JQ8T$&D
4>g2TF3J.2)$:L!)"?sD(@j]AeA^?!k&mDRsiWSgSCj9eO6>h!frS/s#6J]A8u;94n?Rm&lK1X
_qfKe!C,a,*!MV=a7b]AH.2f[h.?Z)CS$>0^%6,HLs?5+^B@Qae!'uaiSEXA>pF=)1#AS-;g:
@=kTt):+'#R+tALK1N/52"t)dP7!u`<<X>u9Pd]A6`1Z&ng.\D=!Q=+[=cOB21S)TogU;KDWh
mqu4lc!O^F3i2dQju$$@maq50>A.!iU$t\!@,Ut'?1D5>`5.T/5f*68.l!iddDogl-P7JddO
gg?4@6[<]Ao3>I^Y%0jUa)UE^egSYT"/=J2A\;EaJ#t-/<!q1gK)a0sB]A+KIH.8@<)YKned?b
L_F4)/QC<!($uD'U!R758O=[7I4G.5*VId<5?GHC:m.JXT2l/Ti%8Z447tHH4eUVTMC7N8L3
DCL7/EPgR$bShP@^k;Efg(J*7]AZ:RpF?k&J'1`c8Aa)cC.M_hXdkU*o^bGO@Ain-06`'#FO%
%>s@.?-T[d2'$NO`*GJ_$;Nh*C7B+UX]ArlW,8?7$2;rIF?3$%:AB:']A7pKr<n#`/)a0r8'h]A
@dpa*a0>Wd7I(eQp80AcRh]AmFTP)N2$5j<3hrl:>!C8U4]A9nEdaVRM$a.#Y'Sfs@e:GPUNKR
%iRio!G^N-Xo[&U_Ze;I8TTZ_NB_R_<>\^L;[U=;\.)f3JkK83_(+8h?:rO@Bjo9K9'[@tiF
YW<(flMYG."@89P$]AO:?[Qr.6XD9"QH[q[A\-@jI;<IU%DLFgt:L,ebLl"5d60WWt&h7f\\Q
;i&kN`N!)V<8j;G0SjSD^9C*BC_iDI$e<Nmm`=bn`82J\+^@memo/X?(\iD@;3tC-`jXkbNg
`kXTr*9,?(`b7i&]Ai/fBfa&HaVe6b6=He)L%PcRiF&aJ28Yf1DWh9Z$(D4:FuUKU)k_j8sMQ
/((b>t#GE8Y6sX&(R$XDp^N4%?U]AI?K>`'VJkREOTKV8-.R(nc=M.-r#$*:*/]AP9*5o-U;D0
L(4Z4@$pUU`=*`m;Q"Q^,#)!fR``VK^ua<6MR>s0lSFYrkjS7';EjtU>>_uf6p*\*R,(C+:a
&ug^#-5:eG7NJ6U*?8or72QH+Bu,UebsO5rM2C\k]AS`KQb[AA<MB*VN9]ArsqC@V.pi5+%dj[
0#E4XdWh%A2i_`S9diZ'BM#A49T?/&m7'RQHoB3mTdR>%=,U`9er>pqZK]A#=UKaD,rsN#u:2
GQ"@H#BmI$ol0RI-j"u;W;?Uc?YHZ8)(S?.QNU@I3!L$bKEAW;1S"j-d6T;u5mR^FtH(Y)AW
DgUe]AqRi'Nnrd/4:[KFNAMU(?1udAFU:\e+BsN:s$!1;88D;bhC@c`0taZi&S^dTA_U.V>X#
HiPPgW,hgl/*kfR/NNsH'nK!>O!0C,HCIVHY^]AeY213:NI;!aLMBi74i8YCi1PMdDh9n]AF$G
jg$:iW<,H-(ocPp9AXO&>tZ&J&,)\Ea1SDWi:]A]A\?2^RRE9j9+Y@>.13IET$1><n@YQZdKg%
r%=]Ae(SMV]A@u6<MnPj5Rum0'*Ym:\ioKMdIU5F1!E.42EctZ/=c[k2g?Z""1Jd[l*e^FpHkn
)/:2W=]A=]ABbePmh@VRY/_'4\3c'lgH1Xc]Ak`ZL'/\Z@\N0,IS#fCZ<Xq>4[h`hk4J3_a.4^a
oB\J*L_@ff@Mf;6qlY35l[^N*XA*[BLW?c"/'8@5C!fiomC:rmLn=LjrX`obJe%@6Ntu'*NP
5A2KeBanFj?\I(fOAo+;o"S*OEQ;hH/51s\Jc60=n3:k'B[.dF34YkitR0(4o$Igo3=p93pE
hk,/&6+<uXGQ+RYhYAOY"TI52`*<mL=LG-YhR/SkO"uU`NC.KXKm_KAiYqr(?8a%s^Z1@\M%
b!]AILhu^NugT/c.YlLY?pg!8,qM_=sosAboDJDGoTFQ>8;#2YO@/[G8:*M!Vg7mkdXZ>X&GA
Y)WqcT034M)Y/LJm%USK(2cKOi^,*P[>JiV(J#p]A+OV#'6&Pi6G=oVHbe@9*8n]Af89W]ANh&=
tjU&n'C3G"2)$MrFS>/lQN2WP3Z,Rq"=T1?BXrqY;EA4N:F.)P`qik`I!*!Of>l*:[mC'VkC
)[TY5-AC1)_nEG_EJV>YnS&:\W9haMT:]Ab_Y$fGnVsCD6NLa6SM1gP^F;ILo]AMMTNQG2R-KR
)L5,ZI8fe<Wa%mBMuEJ1olpFphlacpD*ds:]AX,<6$E+nZp<PLW5i'\7(6^eq;?4>><r[YkKf
foIaMRMn?>sc1f!T@7S_ER3e^u<%=.DP/q.K$g@0"Z_oj9/hkRgtn$rV03JcA]A*1lM_a+tiZ
;Qc"tRiGJQZNo:Kia^\*u@V>2PZ>7`mq:BY,4@1B[s4VRO@_"DBDe8JGJ$\lNXX*C:^C;.\r
NG*-9)[0-htI;IA!2N;ekq+$?tS/m[<?H6JgXnIb88NIekV_aBn)fDWO9VgDi>aM<mGami$R
MqCZF/',IKOKmF4mIl8<cFnBE5Z%?3oMT]AJ9Sr7J`l2?,$*aHZ^UM%;es[+<NHlXTi',<9kP
Ds>;dDMtU(_ak^JO'44!rJ,:R.t>eK\XQRu%.mTK2/e!E-ja2Js&ck`,,B!pJpZ!ci?3dc)S
".<=-;[3rXJ6SG6Pm2,*JYr%st+6a3aUHCKGr3k0Z9:YGF.aG8=u(0C<&eR(_M5=:a:MmJf+
DmJ?L*'6K++Y5X;!S+Z&rRi;4d_JV)ClhJ=:R?o,p:%.%48piT%%+"`fd4+cmlg-4*OiQ@(h
[PO3,qH'6<bi`/NtEB4f]AB1d0<8E;Db:N'n]ARW@l-Ac"Q\d)%>UF=e$D/T]AUOS-X^Y^WNNJ'
A9"?;?Al>l6\ee%\KZMaZ)5nMg1APF,<hLA_b]A!_ZgV$NM7T""`ijhQ[1T5O`"HML(i3/@KC
^els(^!eW9M6;EbIq%kd<T_o5D#S%6^E>`UWTK@>2(h'r$_c$_o5m1\c8V\"7bM+GW3;Kc-[
0%-U#H]AeUAiCZr`;u<c*a&#Iql>oFLW2p^[BilY4M77lA"i6U2\#+;lSpRCHVX*iJ:#r[%%b
jr4ZkmlGCg8o7%%(7"H'EkfV)hAP"$FiQi*OH`Q-nSlbq"~
]]></IM>
<ElementCaseMobileAttrProvider horizontal="1" vertical="1" zoom="true" refresh="false" isUseHTML="false" isMobileCanvasSize="false" appearRefresh="false" allowFullScreen="false"/>
</InnerWidget>
<BoundsAttr x="475" y="0" width="475" height="535"/>
</Widget>
<body class="com.fr.form.ui.ElementCaseEditor">
<WidgetName name="report0"/>
<WidgetAttr description="">
<PrivilegeControl/>
</WidgetAttr>
<Margin top="0" left="0" bottom="0" right="0"/>
<Border>
<border style="0" color="-723724" borderRadius="0" type="0" borderStyle="0"/>
<WidgetTitle>
<O>
<![CDATA[新建标题]]></O>
<FRFont name="SimSun" style="0" size="72"/>
<Position pos="0"/>
</WidgetTitle>
<Alpha alpha="1.0"/>
</Border>
<FormElementCase>
<ReportPageAttr>
<HR/>
<FR/>
<HC/>
<FC/>
</ReportPageAttr>
<ColumnPrivilegeControl/>
<RowPrivilegeControl/>
<RowHeight defaultValue="723900">
<![CDATA[1638300,1828800,2880000,723900,723900,723900,723900,723900,723900,723900,723900]]></RowHeight>
<ColumnWidth defaultValue="2743200">
<![CDATA[5334000,5143500,9525000,6515100,0,2743200,2743200,2743200,2743200,2743200,2743200]]></ColumnWidth>
<CellElementList>
<C c="0" r="0" cs="4" s="0">
<O>
<![CDATA[50点已出库]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand leftParentDefault="false" upParentDefault="false"/>
</C>
<C c="0" r="1" s="1">
<O>
<![CDATA[车号]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand/>
</C>
<C c="1" r="1" s="1">
<O>
<![CDATA[零件号]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand/>
</C>
<C c="2" r="1" s="1">
<O>
<![CDATA[描述]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand/>
</C>
<C c="3" r="1" s="1">
<O>
<![CDATA[过点时间]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand/>
</C>
<C c="0" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="BondKB5" columnName="VinCode"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand dir="0"/>
</C>
<C c="1" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="BondKB5" columnName="PartNo"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand dir="0"/>
</C>
<C c="2" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="BondKB5" columnName="BriefDesc"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand dir="0"/>
</C>
<C c="3" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="BondKB5" columnName="CreateTime"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand dir="0"/>
</C>
<C c="4" r="2">
<O t="DSColumn">
<Attributes dsName="BondKB5" columnName="BackColor"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<HighlightList>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Red]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[Red]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-65536"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[blue]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[blue]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-16776961"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Gray]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[Gray]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-4144960"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[White]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[White]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-1"/>
</HighlightAction>
</Highlight>
</HighlightList>
<Expand dir="0"/>
</C>
</CellElementList>
<ReportAttrSet>
<ReportSettings headerHeight="0" footerHeight="0">
<PaperSetting/>
</ReportSettings>
</ReportAttrSet>
</FormElementCase>
<StyleList>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="200" foreground="-1"/>
<Background name="ColorBackground" color="-16777088"/>
<Border>
<Bottom style="1" color="-13382452"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="184"/>
<Background name="NullBackground"/>
<Border>
<Top style="1" color="-13382452"/>
<Bottom style="1" color="-13382452"/>
<Left style="1" color="-13382452"/>
<Right style="1" color="-13382452"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="176"/>
<Background name="NullBackground"/>
<Border>
<Top style="1" color="-13382452"/>
<Bottom style="1" color="-13382452"/>
<Left style="1" color="-13382452"/>
<Right style="1" color="-13382452"/>
</Border>
</Style>
</StyleList>
<heightRestrict heightrestrict="false"/>
<heightPercent heightpercent="0.75"/>
<IM>
<![CDATA[m<a1ZP%iNs]Ap6iQj><,;VG<PFH)_S'o/(#RQ<K`7VF[\SU108j7--!IRkh=&k7a,[W?c^`"c
9K0o0An_,@m[I#c+Dt."#.GFRlotq7cNNC]A2hr56'[%H1nr?]ArukOCYq<\4`5$==9Dg7CtUS
ZO^AXP03bjd]APQ9l_=(p1=3L]AQL<Glc,*!X(E&'P.gJ8=?]AL^`_,ro'rgjR+3;*6a[8*MXLi
+_Y*((kUfLTkNPa?Gj!<di0;T%utnluCc;Y1bs$iZH\;1[hHm8rg=g*p4%i`5:!Y3P8m_A_k
!<Gp<8H+K%_2i7;V7(Z8>4WKQ+cI[QQMR3`Xr?I!PuT=AgCVJ'9'0jI_?UCTi&;@d8XY'ogW
&4_-6R8'rq9I)eafaqZ>9h#ooB`OYGPJsZNr;5',P6G7to;<O%S]A_[W1j.umc4NgC:t+7f=E
<l+a?-HLeJaXM&EU)+/pMVF+`V`#nUcIC1e6pQb)9ACK5:OY/.n#loKER%Wa48)<\P[ZmUo+
,goK'L0dY8h^[Iq4T=XlHUFH%Al9UI%pAk%OKXm9N`6?";^KC_*Q[SCZNr)3`m0_.`g>GZF*
l7?l\:$1KB=]A#%8U<0S-8NpA-.Esc3O@W6h(%l<qs$,dXS4cAXO$Sq%o$WUCN=<J'UHiT4r>
>hpn/JW^^j_mW=!Wnma;i:9UrKML/4L"o"A!52aiWWRK_\;$6R>'QF3oP\)*:>]AFY@A,E?4G
FcjZ:`tJ?CmRiI_+.aL#;=2oK4.e8XL20lne(Z13VSaDmQgAf.ZA+E,E#ThI'_bcAHR9uVO%
XS".]Am+^CPUMI`-J#A'nNM:98m\C^&C:.RtPmmV`KG*oA8m]AJ\HdDlcn\IpB-':;-`^%X<)5
,<aG>5H2]A`-K*9I1W`!%M;Hm\tEs-9AGk>jNBD^2d]Atr=gmOi`oR:C)qi(%ZO3$(eA#u/qGm
pud'j`n'SeiM3.=(cV)]A-+'^3j]A/:NLsULk]AnY(=&+@\[78H`hg9>@").5lArHDU'E%:UkcK
5?WM0GbHN2Z)G'Cl^]AkVUEk6N/IE'<'Xpq'!GeI(oa6H>p<bb'r%2)bbTICLDLE`2%Yp#L?J
<9*q2o"4W*IrMn>+"q\7,DT?.+buY]A(D0c4W0u=)>$\)B@SO@<JHo@Mgnj"h<5H#CTP(GUfS
;J:ZI7\q`>7$_.^A23n$4:;ZJ0j_k6Qp_r,/b^BJtPsktSMqpu;"m!.m1@VV#'pS6b5S7@qu
@\=g\>!A1$5dI#F9IucdsKc+OF_QcY0?ETRVbbu)>Ye/s(067,8XG7uQ<jA$QXVpZ.R:6T3$
0S'q4J0`c&Q)\Ietdg',d[#`.Me2/R99Pk0>4[1Vd/5&G,o.IrsBZ/a\9&HIHD6^RA@D`YK;
$?-TXbEAL/lbr$.VY>DBK'W[>3J*U92E>m+An.7?Z7j&EqLr%*D%1;D:2,H#i$l!her;3C]A_
l[21b+#:'.eM'k$Bh%1nM>@'/1:,ZE/nD,J$K!.26qJmnO.Kj9-t\E.*5[7$cWbBES-o?<@L
j6?n]A2AZ!N]ANCB+.Vu$m-S#2Tu'+hl1@#&6Q)Mn"FF@)Uo.LVd6Cd^r)2e&]AZSr,bgn65s4V
a!R2n-O5'b9;F]A&97CQP_]ALQl@:D;Rp8dWM+KX4[+(&tf:QS?bLZI>>Zk8'9-:V;mB@E%I<L
>Z0&DCWF.J$j5\ce^\pnd.Gk/nS"R&VDgtr5a*ra#t$%`9=]Ae5[6t]A6PpJY6=WsNB.fK<SA]A
N<7">gcaa%&uKKWqIF[m^1)If_b065]A+#QcB_+(Y*V'r.4cBjiVAXZK=,^/1[m,i:/T"3%VX
</he]AgsiS?dctMur:E-H^'%Y//t0aA2U)r(1"M]Ac6?<3Ng-?8k9JU*4!AT'N5TU&'Da(gI%;
_>').`tg'=j96kN2[:bGD'0aiqMB?b'@+R@]A/nTcS:3SgjliMlRTr*8?Cb/Mj*nc&_(Fp@/;
.@]A!3o0fF!:ek:cJViWZ8SN.L)E?joY5iDil-i\En;.7_m+bTY!qO[Z9PuV%U?3<d!gG*4A>
n;:l:pg05#[GE]A'i'!t:q6t#E6[df5,mkEk$n;Gbs/9Cf)67&)))RM_AK,CXut"U[`A$[d`c
T)5*t6TZgHbiis%E.0qfbP)NdZ0M\.+Vf?(VZmB^c&!:WJfgVtioVK]Au&^R?t]Acqc8fmH%2F
?)Xd;Q1!-sGdO&BHN^C^IXV%@o`YDZ.4L'83sl&\G!A[!^@td]AmZ73_h5M5)]Atp@f09-Zb6n
(:8'/QVc(D@_u2(PA&D^CC+nJn8ffhNi6C1_\8MkX"G8p#9]A.b4hhUD%2uSGJ518iB2E"lVo
_TXI4&;T>h0YX`AUU*afu4.5c@*%;cR*g5-KkJq:4[5fFm1qYes\uf#8I";88>5piY/?O9%E
LinP,GX2%^5@&^d)Yda/;&?=j@IniGB<hT$j^)+J!X'H'kD0Y3*)EB&'f5u;!.pZ2rBJCRiI
Kn+PWID3_QJn=IEjkB57hR.JJp]AMB(!bH5!)=pRFH[VOL&S*g.W02[$a%6Mq?efk;/;S$I+N
;KJWc_42F`@tbBW'eNHDlEadSoAa<bf_N]A0!fl#HDVrc(]AK'mEAF53Y%C17kQU3Zm>*&LneA
Y"m5hmp!nPNO1&SpC/R(M.igAQ)q3F:kND2rFP4G0UBCMn$!n'h!:2[7WG(dhLR0dcD">!G\
O"?[8!cL3(3F^Dk*7Tg/^D:tJ$k"?pSR\Yk=Kc4YKUTAZ>V]A$#m4JFjK:*@iUmc5fj-b3A8S
c*t;e;LYf&U.pd\JGS;7l<=lVhGB'(N_F6iPZN,[;*?_7)B5CIBqGLHd&#K.iQ?8_qGf!UAR
I?Hjd;`F1e$ucA1#0^m1-@<1:E'J3F[4!>/&//^1D$?S05p#lN"&9,l>.-kZ9m=FO.[)oLZ4
+aG1tjB?=<G7&h-5?ZY%%\Q;G%9"=keoU6[kgsPC4>,rPg$K!cREAfKO2\+,pjuGtXnV=O>M
7d]A>2I$rEb;MJ\fc;B,aq,ZA(+3O0'Pj=*P:c*g=L/e4&Ae.n*f$(W"TMgcgU628n`ojf$>U
Q?PK`-mB,D4&"Xa5m&7st>XW1KMuE9I%"8O<T27VhaY:G4I/&//b$&hOW98!qaRs@Gpob??%
rC*GVXq[iM&)>p.]AKae&[STnhL'#bWrEJIUBTX3d"+K`ldYu=cp@;>QP3eU3meK!U9;tJ9\:
8X8EYtmR;TeH1M7Hi['mp)'RBF*4sp3OYESaKYl2TDIUa2UV,bug1GTRd*dM^r0V2Ch]AWDN1
7p/r5le,>A(*b(#D!;"6l=rL.nBsB]A7"Ub]Ab/b+<2RK%nGFl%X;!5i2:&;dPdpWi;>YLC6%I
4m>F1X>TR[;mHO!CjAH/3A)BKo\q=aQF6K)AW@Eq''[p;9\A=hN[:i)@5eHTEG.6c?P;iip?
&Mo6-hVVm3RDt]AdaF6dh;b>.@G[ojX)N>a]A)^Y)3N]AX'e%-MIF[=cJU+>Wl9iA_aLC5p*c0&
EMGIJ9+hgXgT%e%[08js3nn>fDL+62'Mn+'dA34!;TX('^WM6o_;rWaLX4;6[]A9QIOF"-Y5$
FMOQ$&k02(FU`q$p7b8\(n3M"=\pr,gt%gHdNfrk51\P*mc1f(h2/W\<a4n6F&cBnZrA7@3?
m>;rVKiuf-(Kt<8jEiFCH9,md_nBS,7(LtfF+R:1aV&GPZVpI4[MQ\j$aPhp_ITq@af2!<We
>_<3/%VXSo%8L`il?L/N*)0K3o)sMtC*/L0ejQk/6"@?;l\Y^Ml_bq$ZHWX88B^[(odqIQ&,
bOJ0'i_ZjN#,_q/fnWn:o>H"a&14%_Jb+jtd1T?4P6R$*]A>K6&.j-'(7;;gCu+WRQXHTL9X)
8jJNrXGQj,K]AJ#-*Jb7"]A^nf/3Z)]A;Pct5.He_&X(t9@?"4drE:3'1Ps/?F8n`N\0N8`IphR
l'>;']AUS6'=>@Utr%_)u('+r%NZEgqA%JWpK:k=E4>7d?F=6^4R8?b=`oZPDUb%HTqO#?QC5
Cn[]A0o!h\XX%Q@Dl]APaPO^aI^Ve!H8\aQrMJj*@h$fVD?(X:dg"Y72CGo[dY_Ko`ji8cBV1"
([0mQ@"r$t4q"HD_g^KuSl"0BNad&?X\l+PUl\?%2f0h4'"tUuZ\.lbT$=?)p@@0`fg@_\PY
59sR+[G4jEU?lVO<HGE*`SkajV7O)QDR;r$bRU)ek.&V0h,Z6MQ.,)$NK\!_8R:@KbZ@[1&T
Nm#rBLb;3A%%no=ukfW+4!$pp1]AH-jL<;gZ9%5?(*Q.#j,I<n;qN^+Xn>IlpUd@/jan+%8n@
9s.WKA0iW_8`Wo.Y:<?InYTL/T=@UBP5FojIb^oB30q\*EM?4l>O"27\UhP*)c6S^6^i</c3
^&Y&e=_]A+F^:/O?Ro22`q\*ME%HG22a+7g#Q9?k,ri2InM_O3O"E"`KfM;ZUo$4Qt40'=ITN
E.?((+ct"5-)^O:n$8n_Git48>a/,e+rfgs6S<-;Z/X>6)6:F@N@/Gc36tR+N#Bb1#j8.[Ha
hbhJ(-pB-f$hJ"[+F=U7PRCTK-8@sWF+$W<W.qpNFi5ZP!5NIN(5RhE1Hq8a!SF%8[r#`dZX
L1?iMJk^6_]AUnI*mnAd:&`*hGU"RQcj7$Ql;>d'7(hHMc@Q0SKrctpArf9rMW@pT.ij%*A,"
TH"m-1CBlQO.LA.Qr<5Et8=pT,MU5QZSM_"?uAdlSbV8\KLgf-3R1=V*/%irk/o$_aX7oL;A
/j"h(CX8hArD]AT$KoY/R0\63n,QQ$1<DU)'kCo_u0#]AeFfJ[Oi0QK)g*Z.Rme]A8A\=eUS(Y/
*l-Op>X+X_(D.Al2f'QgtD>C\u>-Z)GgBp$&T1Kd"_jWtNLPUEHjbjIEPPq-*J*$r78tN[a.
(W9kO74*UKaV!Pf>`F'nG/0`IYNdd:=?@+F)Xq7#DDS)YAWth5!UNn>\Bgg5s+\\B54K[osV
+>I/]Ao%s*Ri(h8U^TbVQL>JR.Zt/@YMd<.D0oKkB,oSNV46rllr#nq9eI!D1TV*f'mNGXQlB
^1b#d1/Qnrq9X%Z3`h!FL"3/DQZ-UiUK]ApcPXFrbMlh;b83PNpe[E3/rpiBR7%7f=HhoBZ\r
6f#K/b"33Xi,kpT_-.)oL3MphHYe=L0IdKPC!41#`#\IfS/Il\Tqro]A.l`=)ZLuXb=*.p=R\
.=E?;Lmd(5/&gKtu=fdn<X%h*F^[[GN9jfs0t*=<eQ:$U.'?CLGsoqJdGcpBL+-U_VT*lu`h
enj*m^p;QVml3gq.o92Ssj]AiNucZRh11Upo=#p>6kKY-XoZqo0?C(kYsl[?EeQ+u'-,Wfhj(
#rE`dj"9dB49GH>&GD.Vb<KdR&f#!%06mOFTKQa=?4pS^r0@H_5Q[&D8"cgn!H:k@&EjP\C>
+\*k<(VW0S`M0%2I]Ab/]AAJ2+1>UoqKR0o%"kWS^j(t*a%dYV#j8Y1bQ$dMo,ZVN@]A^LHK!E8
\[E3%.jqM_Rbn;CE[Qh+Od8kRUb^2pD=(3n/PQ^D9HS[u5(#8K2P.[5Ifu^giL_DU&.O[RIZ
Yf2@kqJ?40]Ac]A1Z=mQr:\d>,ToiAOK8u<Gq&,>1:^NbD)fA'Arnp;M6Lc="fG;a/I,*kO/um
7#cdWVJS_Xl(mF7G`R=,;\AmVV7e@XnO9TX(H>[ota[NIQPqq/_X%,2\TAUY%N+h3&as>nG,
J$[F:G\/*Y2@Jbk/M^I+FNl$LpQ0C,&AU_2-gmd1N*_kW9JpVp_)X2%\;&eQW-g/4*=#LF*#
[0,H"h;;p@khQ_P$WdZWA^B-OET.L]A%$%dub_/;Ue#_[b;Ler"l5b(jt*hFBua$smQ""0Slr
!*-4tb/%Sp$@_U`_es,n]A;m-Wmf()8?(bih9N*Kf4hBE#n0'+&r).!--&0`rm_)85/ZpS=;i
F57?I6biEt/a_/=[ukAqB`37^6>VqkulXZ/Z*@I\%--84(j3Z-&!P/8;]AN_G5RZkST5D\!L6
5Y@6EHV0s%[@?G]A@AkT/\Q)8jG64kT*Thk49JpuUA@BO.O(Z<7':HAuY:Ut=F&9e<_mgV.US
%S8I^r]A+hXD-T4@K:;lP)`F\m,V"4!$s-GGqd7+*GASSM<EYLLBjA/hN3ffJr-M9<CQ%?<Tj
.`:L%8Ze1ES:d[Y$rc;)V:W%8"RTt/*"hQ@p+^b^;sgtFj2155amiJd>8KB2C']A%!8d^Lj#Y
dKa,f:-Cc_%g=XMq*&"3gMJY+B+R(fLu0PiY6>[IId;,G\1>K;Qr_lNQ(&i#h2iUXg*31E__
=:%>A6T1;>Qk8X/rWC#DY]AG78@.u]AuN7&N/0TF,.:H7=fo>p?0&]A2L]AZr!IrsWR`HNF6Q`O=
TZ2U<q"_?#tZcGD62Q7Nj`1?TJA@4c*L8-s#qFhK]A<s=s&4N^?0.aJME>f39chWJUSY?N;]Ao
KTE91a";=me:u.&#[m[!Ls-ZYk'L@nH4C7_-uXS"#(l0o=X<8*q3B4E.<XL8:LMUJHQ(+1=)
b*/Yn+&[#ca_kpAb%Db4SmGo9?+aYS!`A@P,$_UF>R@<1`Ege!l4RM>4I2Xrbq(g&J)Rl<6:
0c7kOR@nS@c%-Vsg+7qJckh-6^ZY(G3uS((`Kr9F=#(d<&LS?*8gfR#f/fZpq!3aK2=f]A<r]A
BNsi\&2;Pn)h5d%RphV/8c8idl1UgsTat;WM3<Vd@!#f$Gh^od9MPY2l'"4tMnKjg3XMBAQ.
IX\CF%6s'j9i_jBQS/M=d]A?`"e'XJ-ZW\AC#'o'%R/sQmr5/#V(ehEfc(6Lnq(h&.dISATmZ
U*22PNeH/YE00kN>qo7e,k+C<cj,*.Wn$h2k5t`/T"-]ACJF#C.^9K7)Pr:UfW,*gkgd2T7%$
A0'N_e62/:C;js7!/$NpO/cb$BnJq,EC\'mDVcFNB*miglCVcQkK.cEN;FIg]ABFMcUunkM\u
E&0?0"N\j9+%t40(FnF3rFS,kZ@b7u:tlX$:o+ppbNanLTmjt#^5(6E@kq4c@<10Db=+_VPj
Xs=O>>52@BV?VF&iCq,k6(M150V(K&qrf+ZOP.;d<WdEJL\fpf-^Uo'BC^TndD#B'N8`q.$Q
)mQr%6+O2XIVD%sYjha%agIMkn,^`qK=Bqf6KkD$,_;(QU11h04,$@TTH4^@c,1PTSPg(2\,
h'iEaf]Ac0mgBY^HY+9hd,@3h4]AS@Gg9%su=+P"VN`luh$Z\1AcIWj\igeo=:J2H2b/Gkq$CZ
Rro%+dUS9=RJ]A\:K!IJ$Vt5*dTFDsQ3lG-IU/)/n<&r89!,SZs54Rq.,$2V@#u!9hl4FD[b9
+!E?,6UNKp.SNW@&70h(#cfHibnXh<Zb>6bip[")*;0*_;dJ!=W0rGiBa^N(n:,`(D4S8/7F
*[p9"h9T5!I+VQp@?",ghDE)&f\\@?R`il?,J0,U'qb[k&8HBZZk*QY?M1ni]ASO-esbsA3iA
k^l<*R=b4O.PA;>1j-d7?Fm:Gt=e[AeQasH>`YOUNlE00;m__p"dMAC#W@d;p52^l5ris4hZ
Q\XCLi1"7j;-W.jkaKNA6G4q%SfO3kF%\%6_;L^Mq+2?*Tjmhnu_-feSB&TK%:qcL'_hSUZ#
'gVfXgGrVhhQ.[F*!`9`WcVZh:Kme9X+qJ?,Aac,DN#P?A8`U@h+k@#S\`ZW"[\pgqU%H,/?
<*+S,4m00I:[KEsfEuaK-dSV*B"(J;]AA:@2IV:MAiqP(66S6lKLJKP$>,iKlM^bgXLWMK(-#
l;9I6-Eb^TY.+j<NuTaj+Z<%@]AMK&=jd&EI?89.a7Q:qDjUTkO%2i&LM@W;%c.&79E_S%-nP
U\(h8%ZYs3,8u8YaMj;t02;\o_;Yrf7F-!uG`-EJ#!3+t\0g$+U]A3WeGZH^%@d_fqNHr5h3Y
;(Gc1STJ'DPXg=nN^^.rjfbEpACFY]Am\AQ*:E9j_8aIm(N`P8;-9l3)[m)r%s58PSrKr<KkL
@62^a&p"X)s%`PSY"$FQ,/E_-tToS2_[%jQ,K6X*6?s,I4)I2KX?PaLB6W'=k<&#r1;:[9&&
r8kn]Aof-<Y]A';J0]A]AEMGY5lrB!V?gd>l-1j1ZU\\4ut(o`;'IS4-_563^;<"deIVPG:@7:?T
8OA$+4K&<djE372]A3r%-K**rn*R\8EUMYC&XCs^p#F(M*.-8d0@JR#\rm5&QjqY<NbQISefn
OVbX(7AQeq9a15l5NfYc.9)VR=CL(lM0Hh/I^Zc7MpGcaP-Vni/mlGGc5P/FUep-T_<s2%"L
</A`H^,jRT&h;r&`X7P`52pJD%89fgUg3=ai(t4.gQoE5!6M[p_"HX[V$q$K"_<Da*`9r]AsF
#*KGN6ppn$3$Z`g+NiTT,Ioli]A+:1VAJC==V]A@Y-di`mg<RlWFjS;K4p0IeK.clj/pYTm:YD
=]A@1gdX#c&3k0p5:STRON=R(e1`o3>1j?A0"aq!0)=8F!C.Jfu]A\Hs)S<a9@Dr5NDC)Se[ZX
A6`I(1OS\>N3-H;DO3:f'CPpkajQ98MFYbQ&XLAD`PLQqJl:7)%-A:<V[$bdGF1[17"RB"t)
.S)Gu=97<RMe98(jEisblU'D<MX0#[hLnUb5jnHm'Qa6Y!R\EMPb=2!\CqS#[/#k$e#"Ehn2
@$R(kRR%1#IDE8.abMsiI'U0s#!,?,?[d)e/-#L"*:V)N]AMd^2@E\:?e28+I%TFn^!J4e5!!
D'0_HN,MM?0LQM,K$>T:&DRh9RVimZQ5#OR6Lib)UBD`gkr<=!g%IoU.NUdl#m*U4gb\Sr&!
NC1BTWBSreM";/V,XO3`d*2NaY\JPJ%5A:n$Qj-Y1kHQB/("ad]A26a!bmlkJ//+SQAD7!>Ch
G7@%b4^Z*6t+X2q&#@l[tfIJGV9N8"g@S!aT-CMoA]A%,3j=.17=mhO?9:+4YVJ;8(>Dd-`#]A
`1,@L')MKH.,+)sooQWkWBO%:85a2jE-KUh@_Bn&6.96_=7#1L@i,p\-LNV3'dIVd\na3Nje
"Wd3O!)p@9Nl6P]A1Ld-4RZn#;n&7MI"R;U4\`K*hW>^';]A7qa4s)KPR_r^Ks$:kbCgKK>?)f
S8-EX)uh6>U?I;YFt+irNKa_s'<P,<\GqA>3-0Z(3>SL@I;>C.Zng21n\($['7P5+f3;R6%'
QtI8k3*INgOIFBHk94/.LFs%l>4qUc.OK_eatA;f>91`JM8njWMg-p\j[:p.UZS?+g^T?_IL
IK'_]A[N@7(j>3LppOqqd^TiI[^$K]A2e^c_=GfR&@]ARJ#t!fFhO+$QpP0n!?4CYnVq(nAU?=J
69pZg*W>ESLRD]AP?R<3qq)r08.rk%8IN=`pfU7F1Y`+SHQ+#)Af<nln.7ApnOa'V<KHM/.Y?
:"\0kV3I_mu/!2BTPrqgL*D^$7AY7U4-%MlV(`eL:`tsSMo'eXV$hbE;QO,cSF8EkBg.%CS*
EJIbB5iLd3o%61n`M/#DK(.9.p7Qf>k%pCPk+K\)b0[L<C)F-+9LF^%FGs#L_JG7Xk^_)T#7
6GthFYG$5EebLJc0\prm*d0t2PI9<$U@$mnAo>aT;*cm.5^5^,Se3qA.4Pg\0K=p)J0<<T\c
HHmqI&IbA$qI=kuj5j$IIOD:Ls<d[&Q[*Npj+I@m]A%h2m;$t5IRQMks%Y)X-bl=`4h&hiF0n
qUnB3e0qYg%<8ciFhQfV;<$TA6.V\;D5m4n1\]Ap5WdCV0<KW-?f]ALQ8gE)e!Bf)TcA>;A<uC
"Ne9h080ojc9dfN4?]AK"&VRaWO*Z=J!_\&R9,hPl\1bAY&6s<:j0a,?:\41hg<Dp*I[CD%Am
'%]A180s$C/\2C<&.(6RGCLO@a'AH7^?T;\PeGF4-2N93RiVT$;sG>a8;nT4QCB7;#qWjbOKj
)+-Fu;jd)0667DPZ0Bc.H13Q,TQ*s(9.klDXn#>aRM0lF8Yk>01q&_G&AIe2gT*i*fXnF<--
Et952/o4*0[n3i=-n)G3\t*V!G=tb>^TGm.cUkk[SEfe/k7DkSi]Ai)f.3:6>u-!k^cC#MOch
O8m:r,r+G%V47_GD4LOpc%HNQ@j(&^g^-\*Tc2F\J!XNk9rV;p.1G=.@7t-[)^To$%1Bk4<D
QfM@$R^G]ARi,Y]AS8ii(XO9(slb7CQbf-O#;RGY2)#VK:f$SiCAihjB6@0T4;U+l[0g8\1SZC
P>mQVYAF?kIA^:E-KCT1tuM<7aD6i9`O*a"15C)"cP;'=r_Y6UCV8[!Hbb//J]AY$U$\A[RRY
f[%YTk#<g@=l^p9"B/$_$aZoQFCSuWelW%4*pb,8_b(]A4r(Yhd/m,LUR/2du+lXcT`n&0.M,
Ro.NP;6-+%%a(VrWgZ.XKd;#Or8pTr(1ih>q8o.V%mN>TW$<<S`BDX!m>S?tU_Gnp8p*an"3
^af>P1nU<eg=f\o#@67%_rC9J%s2<,$+"ImRQru@/]AotNXotk:(dAd#=`B*GFT8U_82Q;Eln
3N,&fjM?a2LU:SZsAssR8/(p%4GdDEa):mIi$<KD-BS5I0gJo^`q%uU[ulD_q4gXF/JG:N"B
j(!'s)sHYWALF&(QmTUND6XI-&?Ab-$@WGqhZQ9.3"i\L8I#r5W!F-3ac#Ca)b#r5h9p=OF(
Xg#U(?n3JT1OlBY5G^fFOb!o5<'+GIdesV/7PLHOptP+!qoM?j,SLQ5IqA.t#uLp/j".sZmT
_'36cXD!cnkOVNh7-R-`#$(%Fh,%:hOqg9>Gn0A/-un^+3(\+EW-;+/D^%b)\le*I?^<s1"R
7JL@0jHe7@J,W4<>HrPb!q%"Z@Rj`^d!ok<U=/a!Fl$DgPlQ^gKdDYT8@LB&7[+bB5iW@X4)
\2r4YcS8+=<$*RpZ:US>6kAhOjP;:AK\5OXq7r"CHa:R\;jqfK<,@l=aUOLY5#:>D)#'W<F%
]A9gkeX3YM'`jf8Z:&djglVId2j,G*C,VE%dRPDH\%6`P!E\e\1[?KQ]Af9d\l!MBA/5(LdZ]AS
"_528M<Q"fo/sn3cet(`X6C"*(2\KP-[X%7Y>k'oonNm4n+V-a(D[(*,f6'rm^8Js]A6o;JpI
/$@OC"8<\`JVfSJUr-OP+3@WMfO:Q(;Vd',&;BNCB;:9h4!p\-R0?FP3kc*5jc4V:#)OgFT$
pAW+RE<2<C=KaKA'`aa28+du&=pZC%\XX3':I6U6G9b$YLis5uUF5^iH]An%Sn!>[Oh1Utd&(
jW]ART5JaTcf:8LZd'nK_UViO&",D7$,O(JTiJ('UAJ&!q]A/V<-=(kp1V\dVnKkQYj^.\b2?(
+noc\!HhJDIlQ'f4Qg9E#+H*+cfR5a9'S&to/)KSR/aCAbmjAGlc<Rbt65UP<lf+bofF7IJH
p_+RVY;NID,HC\K=o$3W[N"+RA"OmrFdu!aC4KY`Dp\Yt%TahuXLtl;*XS:ee'2r!4%Xc:!R
%Wj1rbT8o;rIM*gss=)Idr7)UP]AA,49@J1H&)^Z8kn`pOV1fWt(sM2-pHt#<SJ4BN&!Nn]AIV
1%K(em&L+mSA=0CVQ"L;^e5DAEZ7hG$$h?oSGK"sb4)`B\4k\U[AYtY$,V/c@[aP<bF&oM&.
cMu/f:,FuK1Ai)NB?ad$-larH\Q/R>i[fWn#8=3l;NkQR+5eI`6t:;b&/6oK%OP)NQ8,RHWJ
]ANbVZTg(7i&^>-9_'Nfh]AtBU1*K8[dhkcH$7E+.!22ipB5ZY7HpL<cKXJ(*45tbPOd2mQ#8=
%iSVuWdF[1Wd^/DAu@e7JetQ=QT2(b+oue?br0XT3n0\n=u,E)1k=&Ep6D(\1_&^;S:;pcQ.
i59FT<J4(!B)*p1j>'Ro5HRP#)TFcQ5eNT,GX3p\-]AQ=s7YFMBDPU$9L(J@d7#HRN[R*Y1D*
?(go&<nqAA8Oc`MLebMfB<1?J9:Gttu)JPbhWG(IhM`"H&OkQ^lOZI,sh)Hh4_sg0,HA6M?Q
$VSa4N77`SrdhCp$SaFC&T#)Y6>tOp"g./V(dC_Eu9XuMJD]A%>4glAqF+`7M)dj43D.9&-cB
J50Pe%Y?S`D809>f4Il]A\3pTDJ`mRFk?N4>.pa!*HsFfL$dJN/c;M91'(]A,"Cl*Ll1BU1DF2
_B0&8"DV!1*-+qp"]A?=;9OEqRSmd!Q:)Bj\5[`1JA?;h>U'Kh-jpeK1s$HS$nPOOg0'Z<li6
1PD=f$J?gO3gNn9;I+O%0=<>VR>nPSH<]A1s"Ck:AnaVa]A\9U6+416F&'E17Q^Ao=>&R!%nLY
Nfe?HMOREi7+!FQ5#:eobcPcVEH`Mn'jFfaBJ6M4)Q_)BPp*5V*:Dr5b2-"4Sgc951dL@<IO
&n5>WQgD.GLW4Uf[uL-CKBM+T%@C9Mf#*^_up>to9C*1alOnmLPJ>9VfVJd8pa1MT<k5'qAu
o!32GLU\E(q#8D\RQU[Sj1OBXR@Auag=,N__(#+/iGNr'P^aFb>L?a8N`LlpEp)5KV*gFXX-
+fZ'uWXTIFDV4U@Bgu#j\1">^I*m&G72;sKIRuU[IX%a3i<P'q[cqNEc:)hb/Rman-qjphO2
A?/f/Ck[Y)k*TaUcIu\23fad>*a9X3$I4DO2prOsTfkk6=*hnd^_OI``-UauPfVGUI!"9&01
2`'O.2!.%Rs0.&Dg1M70.OZelH?p+1<Vj$I%SUVUh%M6j^i`<h(pL1;oB+q71BCKaULhS@r:
;#:Qk6(oCgp\kK^d]AY)68@+!@PFL73#FFOgD%12ep8gY%24BGIGu/C">N#]APmgHQ.?&$iqPC
OcUj@FUT6tM4:!-=@X)<o>N\$dYSX>S1:CCu!bj(PLO]A8p*oN$=^H5m\!(uGcCikM$Y+V0jp
lL?JNp"4hI2>&1&"&C6sU?j.R`NtVVeMeLp_jT>r[VR$UWoq?@>hHLTqfP\Tbda65;W@$!e]A
Y"*J1">D+(q00b3m6hh^mSbHE1N;6A:>kHak@+,SBTM(;VFHTYLS'%U*L`Y+EJU.T23B42P<
rWuGih7eZ<h/Zk&UY1Ab&OBqF6b4FWQq"uWYCIr4,^,``L':lVt/QAh0Pc`rF7(d5?6:UN*9
\[A#OIYl$%P7F9Y,uDUUhQXgRFH/c#@5\VW/)AuaKS!l:0-\GPZhQX@87(j9#>=!8b<sMkil
_@S=r,&qpXlI3.Q='fe)I<q;qI5EIqP>b>5cUL.%3k&Pf54Jh*BokeR.*Bp7u4#BP61p5tY2
EMb9Xf`u;[\,$k._A0LC4O_>Lr%1P.$fZumobXcaYukk=(=%Vn"2UH3-@cR+41=?2hm;Bjma
fkV=#UWo#`+L$+8%l<e8a^B9,$I%aNAdcVW5q^I0h@!IO2,01G,.%Le1"]A"\hM#RQG!&[1+5
qI*,&W0\^a7(>8T/_6G3CT#^*^P2aQ.<j6iL5C9T>fsQ%15Wrr]A<<#bZ/F$/9=_QL%1o0]Ag=
$NtB#:]A>S(Rm=033?"WO9,:MM\K-TPP>+S+R&E<0]A6$t$u$+E6L"GkcLf(qg/k"`WKXQKC+K
55B@a@>kX(?K*9TZ%SFb]AF&kBsFL_-)ShS#,<#-b<SWlI=8%=_R/E%.HmG+G_O;=<oLGa`37
91dU'F/))uD#Cf$S9AT;L+"&Z@Fqp5Nq4BODqTNLC%2Xr`A^sa=^!p&Co-uua-:d`M/L"4dB
rACDba8<n1W2pj,SM1Yc,2/d`^8.V"SS:!]A:#LYhPe@0?0HMQWE8P3oj,_fR.6i'Ec3Ph3Zm
Fpj'A#<E-id5PWA_G&FnGr_(RB5<kFG+!869i:&BYAqdKPn^V,V]Aj5-IJo/L\nE\Lh[R*1u8
g[e)IcG@bm-g<Bq>A2%6TBU"f02Dm<JZMp]AD*H1E5D$$o-[_A?[ZJkY$Btl'N16(VPEUs[9#
T$Y"nNddNb3?'u:@NFl[3oCp>Vo*;a=HcEI-m0\r/+@>&Tf0-`2rT^M-rci)0T-\+cVKX4:O
_&m",cIne^$NBder`a*G"OPJ\cJm?f`?;V$hnHDK[EZlm"e,'`r^r/kEi^<^0Cb,M+N\&g9D
[7?!B%0ql#ZGh,DMW@+&^BtJ*Ae4rAW)bn$dZn*<pApN(Nff4oZF#qL9`Sh=D^jBXuTI=5NM
_)u<>/hdcM$!?b@a3rT^6kK2gu[sWHWU4'_>>@CmL,*c&@c(-5r]AmU4A-S!<^Wf6sYnbaErs
'nm_]AngtZ`_p>u$hWgIWU3oq"=\iDA%(:A[*K$eBNekhp"PR@D#a08;^LK(@fEQ?0#`<8hY2
f?-)F^+`HX\#=G![aq^mj^d/`aOdoddc:RAtKX,HnrFBWfU>k@I?W>h#I!f_--Bif9c#eQ]AZ
7dZXK<dO^;.(D[J4GnEMp2BK\>68Q>NdV(S(c(%/%fD);I0laj^RhMb`BUk3glE?mSFDJ!3Q
e';qA-pIM[1cnD;XfSCG.DDs#/otG>J6cU/<uKiIB]A7E$$cP^]A)4Ks0Y+A)[Mn![)onQ)ol*
i+LQ-sfb""\VbKYd>&FZ7LlI`r7Gp775#=,BO^dB[Z38>U"ql[`SZS2#\RraZ'[:RJXqCbT)
G>'Zc$,lG"[$gHPp>SK?N2+r'cLUjV,cNN6#ripos`\g_nB3Fp+TjJ]AS(qE1qlrgL9jjPhb-
ei^Cp65[MCI4.d5J?)Voff2/P8S=tK7eS:`'MUHI2S-2W7u_=;pGh88`WD[0eGYUUKg7K;VQ
bkMcd-+T8lX^<C:[7m9M"k6HL9$-gM5QR<8^TEId$4";5')O9TKIA.GJka_nK8Iac8;mTh/X
6\W+REtuYi+@NRE/A3+'kU\KOM@Y='LQ)^.XVa[6)+Vr*tWMgsigQQPdj\1D-KP:KZUg9T7!
+-Pl0#Hf&YPNpn2*es<qLrn!$8#r]A:<'s)^jD(=6llB14l9d=#Y5Ql;8EVc!28nYl5B4O*7s
'9rNb,5ALq[)t5nfC\8htkK>eYT&T[%JQZ+<RfdAX6$9V>P\YR=@%0X[:&;0%9ai#O9&-YP^
?D^;!T-HJQpJ!sU9#^+sY@$'9B&cIoAAq'K!t#=$+gg`>;7mb8Hf#Ri-MIlo3YL+#kZ*qcae
s7Z!_]AG*?X/>7D_PhNnl5Z=a1Ub2!,q^/T.?]ADtOb&H?[Q7//GLR%n.;=lh/QTT*t@0A:Hs"
s*"d]AeFi1di7(M.7n;#b6qd>AB0&JWJA3IlfF3UN`8H9cZlL:gPLI4(;oNW9>&]AV>gS~
]]></IM>
<ElementCaseMobileAttrProvider horizontal="1" vertical="1" zoom="true" refresh="false" isUseHTML="false" isMobileCanvasSize="false" appearRefresh="false" allowFullScreen="false"/>
</body>
</InnerWidget>
<BoundsAttr x="400" y="0" width="400" height="535"/>
</Widget>
<Widget class="com.fr.form.ui.container.WAbsoluteLayout$BoundsWidget">
<InnerWidget class="com.fr.form.ui.container.WTitleLayout">
<WidgetName name="report1"/>
<WidgetAttr description="">
<PrivilegeControl/>
</WidgetAttr>
<Margin top="0" left="0" bottom="0" right="0"/>
<Border>
<border style="0" color="-723724" borderRadius="0" type="0" borderStyle="0"/>
<WidgetTitle>
<O>
<![CDATA[新建标题]]></O>
<FRFont name="SimSun" style="0" size="72"/>
<Position pos="0"/>
</WidgetTitle>
<Alpha alpha="1.0"/>
</Border>
<LCAttr vgap="0" hgap="0" compInterval="0"/>
<Widget class="com.fr.form.ui.container.WAbsoluteLayout$BoundsWidget">
<InnerWidget class="com.fr.form.ui.ElementCaseEditor">
<WidgetName name="report1"/>
<WidgetAttr description="">
<PrivilegeControl/>
</WidgetAttr>
<Margin top="0" left="0" bottom="0" right="0"/>
<Border>
<border style="0" color="-723724" borderRadius="0" type="0" borderStyle="0"/>
<WidgetTitle>
<O>
<![CDATA[新建标题]]></O>
<FRFont name="SimSun" style="0" size="72"/>
<Position pos="0"/>
</WidgetTitle>
<Alpha alpha="1.0"/>
</Border>
<FormElementCase>
<ReportPageAttr>
<HR/>
<FR/>
<HC/>
<FC/>
</ReportPageAttr>
<ColumnPrivilegeControl/>
<RowPrivilegeControl/>
<RowHeight defaultValue="723900">
<![CDATA[1638300,1828800,2880000,723900,723900,723900,723900,723900,723900,723900,723900]]></RowHeight>
<ColumnWidth defaultValue="2743200">
<![CDATA[4032000,5184000,10080000,7200000,0,2743200,2743200,2743200,2743200,2743200,2743200]]></ColumnWidth>
<CellElementList>
<C c="0" r="0" cs="4" s="0">
<O>
<![CDATA[50点未拉动]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand leftParentDefault="false" upParentDefault="false"/>
</C>
<C c="0" r="1" s="1">
<O>
<![CDATA[车号]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand/>
</C>
<C c="1" r="1" s="1">
<O>
<![CDATA[零件号]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand/>
</C>
<C c="2" r="1" s="1">
<O>
<![CDATA[描述]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand/>
</C>
<C c="3" r="1" s="1">
<O>
<![CDATA[过点时间]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand/>
</C>
<C c="4" r="1">
<O>
<![CDATA[ ]]></O>
<PrivilegeControl/>
<Expand/>
</C>
<C c="0" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="BondKB4" columnName="VinCode"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand dir="0"/>
</C>
<C c="1" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="BondKB4" columnName="PartNo"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand dir="0"/>
</C>
<C c="2" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="BondKB4" columnName="BriefDesc"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand dir="0"/>
</C>
<C c="3" r="2" s="3">
<O t="DSColumn">
<Attributes dsName="BondKB4" columnName="CreateTime"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand dir="0"/>
</C>
<C c="4" r="2" s="4">
<O t="DSColumn">
<Attributes dsName="BondKB4" columnName="BackColor"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<HighlightList>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Red]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[Red]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-65536"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-1"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[White]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[White]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-1"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Gray]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[Gray]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-4144960"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[blue]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[blue]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-16776961"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-1"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[LightBlue]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[LightBlue]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-6710785"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-16777216"/>
</HighlightAction>
</Highlight>
</HighlightList>
<Expand dir="0"/>
</C>
</CellElementList>
<ReportAttrSet>
<ReportSettings headerHeight="0" footerHeight="0">
<PaperSetting/>
</ReportSettings>
</ReportAttrSet>
</FormElementCase>
<StyleList>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="200"/>
<Background name="ColorBackground" color="-3342337"/>
<Border>
<Bottom style="1" color="-13382452"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="184"/>
<Background name="NullBackground"/>
<Border>
<Top style="1" color="-13382452"/>
<Bottom style="1" color="-13382452"/>
<Left style="1" color="-13382452"/>
<Right style="1" color="-13382452"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="176"/>
<Background name="NullBackground"/>
<Border>
<Top style="1" color="-13382452"/>
<Bottom style="1" color="-13382452"/>
<Left style="1" color="-13382452"/>
<Right style="1" color="-13382452"/>
</Border>
</Style>
<Style horizontal_alignment="2" imageLayout="1">
<FRFont name="SimSun" style="1" size="176"/>
<Background name="NullBackground"/>
<Border>
<Top style="1" color="-13382452"/>
<Bottom style="1" color="-13382452"/>
<Left style="1" color="-13382452"/>
<Right style="1" color="-13382452"/>
</Border>
</Style>
<Style imageLayout="1">
<FRFont name="SimSun" style="0" size="72"/>
<Background name="ColorBackground" color="-1"/>
<Border/>
</Style>
</StyleList>
<heightRestrict heightrestrict="false"/>
<heightPercent heightpercent="0.75"/>
<IM>
<![CDATA[h0XELdd+KQ6Y]AY:Y$*i$A^d[/b^"k2CRNmiR0/kR-&t!;,*nM%19'&CNmMJ%5\>n28npqp!p
+ri5Y;B@Ll.jW^k_6WFisZR]ArukX^:s'ikP1CX_t-(PrS6l1HG+aVh*l17mKts73OQb[p)fW
b;]As3(aU^"*QArCbhc?#+F07R:J'Z734:W*VctgmR0dUr)24!n=3o"FHfR;.FH2=!@OJ&iTD
<PR/p3kWqa&l@i[m;M$m9IE+-/1($ZKB'JNS3"PN]APk\n-]AVY?aFNA*r^>VV)?.AV=>drMZC
[bM#^G.1pVB.c_=&ldLqCH[9L+4lQJ#/F/35t/!)Le;P'-B@LZGHi_\?#UJ8bB9WoE>9>lh_
lcWT0HZjmq.<th"OEY<I_GAg6DRrUK-(ROumBT1QkK?t0/@HMNluV28'\JHPmB/hi1J\oLZ5
iga1"#gh>!c`_2PA'KkFGO:HR$,2!SdO;`^FLV)M4hph/i:A($f[I6Y=9:),L*nlCl(o:moO
:kA%;.UM9M%4^>,?ZP9OZOuN;UB&027]A2PO8LMQYU)s[e\@j*qToAF-#INWoLZGI$Jpm9,fG
7NBF9bqqjelSpl^*-DLE]AK+'M&V_N*97%0c+A]A1\l3d0%9A31@shT5I,Q3F2Tt7XS+lo;bg2
Qj0I>;4g^4,&HDS`0WaP.mXB3^;,eGDhnA4!NL[K5kNSh9?rjM8GN<f4$GWXaBF7=NXhs5\C
>d#qu:]A.L6"o3MoNlin7EM7L.B[boFh`Bb6idM&fPTIpF3)P#L=TX25;e3Yp"Y3lANEo+VYW
VhkP9!I`7lI<,P&lfrWZOsld^jIMLIP`mE8bRE8"<35C&m7*G6!^)FlG*E0hr]A8V@r>Wp$<q
rkFJ0>FD!()'(73=^K5%rP?[d!/W)0_'iE2lPFt,;q1YfBBqHZ,)S`"QO<p5H3[8r&'R?=Er
n?Zj?TYqD2;OnPIWFu&&eu/o$h-i1mZnMbaR`,':sMEgZ$2+4WX*HPrNg.A4EMe*^i\+1eDY
+q<+VA_8-]A\\?&Z23iDd'm(CuI*Au3TUR32Wu%ehaW3i`rFTC_H/9Vl2OOMX0\QCU]A^e;K]A<
GMs$BHh%Adkj?*h4?5-[a-]A,f[ZO9@e4:TRS(K=0l<([-?2u<]A1GD22=O-;kQ0b^ZSSm)_"Y
jib/uJkCjfqR-l>=n^.(/9H@l`aMnI5;p80L$Yaq_>O?$IXXe6U5t+R+I+B(76,r@%jm+*,V
bet"Q+g#Z&1<Y-eD*!`6NgPdC7#Bp-I;'m88B_cgg20BYuo',dYm^R+,+et3,+$_,hs&4S?`
UabpZhhE^B*/$nOSl>F\5kC[_^n$m3$Ye9%hM5J%r-Sc*`rA(BWI(%'f'l1=Ffe'25^;a6[l
!AQEAtggOWm??I.,\ns8<[>+:7N@L"![?*B$8P4U9-)maAfYMTgk>;nt38(ZS`?Y.dalH`1U
aHXea)crr'isO1MY_L#RR,[9(-9i,$B>+A-5-50ucad4[rsONKle[;?r4B,u#A._tb1tKXNR
a3T*u81@R*FWI=V#%Uek\\jWA+t;n8ZagZ'<[(Djc\PBI9H4"Tc4bnr6K,H9:e#Nh%b`:8Ot
R2JnHO9o_9mD(G5fLeGHMM_nWtn(0<YQF?m@.CfI#59L`J))(fX:@&r_"A3$O+q++TPA%Jmm
,1-a<M]A&hR]A+-TqJ/s7K3lZ(llMn_Ke_3u5XSEd'cRBR`GRcd]Ae@eYfl2'K=B_S[Ek,L%N7+
==Y4Y@l`Y+9,/\GS:Y=!:e5dp&D!`J$7%,R!?jp,T%H3OlF_On;'4HspArFM7*lR>=2?p4s^
S*sI'o4]ASS@k)$ST%@q,>Z7dO:h+AY+$01SB_Nq)M67cdna=5_W@VIl*>ahL@76T1ei2rHN5
Gge($jcp#K4b3O8qFYOfSn4IK='UI,OghTC(#eh0]AR%odNC[4B#[#cuqC%e!"tpd.*A\X&NA
u2cqFJW0,)_6fKK#J>lg]A-F"M*>rT.eY97[C?+pe`^\=K"Y$/Q0e(g?@>C;_d.'E#M&sUnm2
%i(/O#uO$7X@ZjL<u7j`e0)kPo4[+GtZCn;;bq1eqEc2WIR39h&1giMHr"KD(+(JT@k6HeBi
I`EVADmZYMg?Qk*n%1,ijp/%ZUgEHH1RYp!7C!e\SGc3rUhJXn$obmBAg$1@f'fa=c$UG#bB
,/rbKCO"s*2E((Sj%aVRR;-Y+>B@!PmdR5W8lV.Vrk<f!AP#i&PFiq\V<BNSL?_uLZdQfjd8
:ISc@-M90/*Sj0h1fCDppL>*:r$sQLjP96@sU1KbHAb2oq3ol`=H4-;D$df/raJd7.!9?)C`
EnmC/>h@IELNkD;Ri"Pg(>kmC8biT+XK[cEpncd;g4lNLGne#^)og4u;ViG"&?bPc>-p]A9I+
h^tU(\3o2c+@/p>1[%o7R'mlJt+^sb!.'1<dK)H,=YS*]A5d]A+(cl_B,,W*IA+mRmFF*d1["f
'=L'kH%pM5R^/u2:m'r?L1`S#cr$eDrUDpAL^j+u1%K9\M<O^d48Wp1K/QDn\C_D&%5Al#n=
2Y9PFZq<8NRYZrk1X\OI\mE/,;WepN7c[eC9Rn!p1))R9J0[o)W"E"pm9D7>HWFlH#^-O:B)
_G&nBZ2/DUfW4cgV'^T<G,M&dr2Z>@[2cM.;mUqi)4`((Y;+1^a,ulTKk6gOZ>hImj5oramG
d^gbbd/F43d%XZRpWU3H]AU,$^O]AJob;/7$kq9+Q-A810i:J:g#EK%b;53)8c6UOA<3:kW%TZ
9)RA?4e5S_o!K=jq!=VaJ,XPDB9NeYa)@!nKn'X0RA=+l9Z:!ff%P,R/Z$h-'(>nJR00O_p:
)(=5llK2;=ft\V+aA2HqdIL3`p=E$Jtbl3is5#-65!rY/B2!Aa6(&V-GjZf&buqZs/c;NY_M
8m,+V#@2n/BN5`6cf-%rD@W;]Al^@K@R;O@7l)1iCoVWoIfA:nTo81H")0QmMj@D7O"/=rL'D
Z*%KI\UD8Z-,\>qeV%QPZef8tfU:B%=VM..kHm5qA#$5KNJ.0%LY"4q=']Ao6KK4oUUPQm6mg
GFS9%)pfXVEq:$rHc=>Wklj@i#,J7m<FO6#GUpt<JpD(?Y@soW-R8"D(jDA:2iSQu&&cPdlJ
Xl5j/Ls$^L0n#+F]AGWhbe2XEpkhT=G&O90B/]A#I"I2mYS[<M+_oD42Eb;K<l_7>eZBtlt9-/
f[?Ps,tL@<H:-3,0tn#)@*';EJ50[YMqCujR-D8;)<+0*PB.VV>KB8?YW*XH2\6Bj6`_#mLp
(c/`AhQ<LNj9LVpCQ#340]Ad-3/+K+HZiV*Sn3"#>eb$ffH?1OO\^8.S/>e&/VSqaO$K+B?>2
FTjj(+]A!%uOhr_sr.""_LeHFuT/,a`6OX$SYgjoN;;l_HpU0qtF6ICf!QtTPRHpLqHR&5Z%%
\'kZC`.@b4O[5dld%LWb24?i7$FT.6?/crZ+E1kBZ:F$/dk63u3nXC_hf9T$q[TEP?rr8BiW
CfKbc+&:D>.q:<,cHpnTg*g?N@RDTC?Jo]Ak4h4e7&PkClcH_U'k86Mdn;G0:W9-hGm/6s;6t
3$'[\@?7d8.!%o@7%PDTMi;<pZu\Bd@f%s"4L1t]AT'c^VXQ@E.uFK_,*i#\I^e3:tqqL5,t:
X75Z1Y>\/_G>TY_V[dSUeAAN/FokE.(\Ynel#qNM(JnPb..*>(CVGi7/:rfMd"r>^,#,hh_*
7=G.jYk"$K9_2!^(fIrXB:`=``>:C-bqRi'Yp:6H(*9I^Fc\%K]AdK*B/j3K%ohaa-hX"1POo
IR<`bhA0WeLpW/Z#=A>`96RN/P#N!$=\9qi\b?*jl,K)WfOl94M8E&<8i^KMLELeSFAWD6*D
B0U?TrP=^X38HbLboS,cI#uqk!UJ/jA`kaHO6FMF]ASH]ARct-,?_2ppO)FDq'2&\j:<;M%JDn
)N>rMN*:[@6!dP/d`^2PYS[VFmb`fg,1-N+>;7[b13XA:.+L%i.J.YqToGds\QgAB#tcT35;
(7QC$4S7%+@dMWbQgUAuRId>qZS:"/I\ej%BEAhC0$.&eTPqRo1D[Q/XOd,G[m;-,XgDW6`A
R86d'eUX!CsKFqAEdJLpuQ:)h$`\%8ur)?M8qAb=:#qP=F-TT/sKWCbZn*C6GPIj-hU*B"5@
]A"')ac:PIrF0J@gLr\E%*_plus^uV_OI:B'(j[Li>nQR./39$c;ZaP$WeN/osTeh`Y`=P.*U
Bj<'-q4F]A&Kp*ojCHWElHJ*oeW&N,JM)i#9HK%Ur-RsmcM"+H4)G(l-h@NBcO$/,rkm#gK2c
4\5*pKb"/o/[&*<(03DJrp>Xe2h#K>t7Baj^iaZsl^O*W(m1[Dna\X^lQqX-pMJ(+8En]AUjI
NppC+H=B0lbEECo?%H,H12d[lghS!/2#)(bZMQPK-jQ$2#8sTrbc&cAEu-mI&a&*`LATd'U&
23@YCrH(m_?-NQRbo/h9%Om`Mpptm-5,>;+_saY\!2:&IYG9G&=f.<kB>XD@5KZQ+H0H(VUg
]AI:7IFJ+]Abc+T&qoG6"%VGRf"4JG5LRB9l;.YQP4]A6UOTC*QqR9`?<&dP@pFF/khW8QYk;3a
MZ;1KGBK@S$an!Z^Re6Kd5>g$&+N"AaH]A=d<YP6Z_8@X;+@Og53*0&9m(s-.Aq$MNob02lO;
(?,P*7a+FAdp8]AOu8WV=7<(b;(hfo!@U+mNr`/b%Rg/EB0Zq\Bh7WXO**RH'l)88M(G7rK;l
n_D94X")Ba&>-RHX.Mm/fPSaN`n$!i*cF1_H9/AY2SL,S-TAOE%lW9+;q]A]AiBpS1c;9UZ))E
&B4\CB]AJTNT5]AH,m.[2C?qdlfeFb=D\4Nnq-/]AI`W%;&abRLFDTljd"SlFChAC>(he*,o&uH
5/ao\&Ft#Q$4>GehmKuj,\5HS+7<R,TaI1ZohJk[dLF+Q6@sVt!H<\8?@c$VC(ph,g"/Vnpc
%9ouE\4B<829!C]A)U]AjK"#9cVXpt3#rN?G*d1udY2Tfl+Iinq(HIk3`bS?P="OX-g3uY*nLj
bs=.PQd>4$/86tCY0&:ZJf(PFklE1claa)sVXI+o)WQmW9c<`CNm\s6Ro.s%mT@FT1$>\5'/
*.gUl4M1b<Oc1a5`*b)),HIH.F&LM+U.k.'kOCQs2[q2]A@1b<+DDt@X'bXO)_L>>X8P_b,S9
]AE$.eb[Ycn.Iti9?MY3gNT^`Y)2[K3!=qMLAue8jDE"c/oL9q!]A]A)1F\gdnJMueqT>tLdt1)
dB2f8KB6@D`cX<h9C(t8$G.%%2VPeG!81/%gFY"LFGop9C&Ql$5E3ui$j&'[(Hi4L`_(D5nU
%&StJ#eu/V=j*6L3#9Ip)kr$a-4F5iUTf@dB(`$`Fq$o*=S&^qCD^1K$shno)&+_K6O%3$$q
\ejl/9ucQSa[n*,@kl6=!Qr/`;OO#VPH7cp-*g8=j9Zf]AJsI,DELm+5*dZ;?.ZNO)AT#Y*3`
W8Hi26]A7N3*N%\nP6:!2%;-ZaEV6F6&@'#3]A3Fjc<:WFVQS'f<FRW1O#Kpm7>VKsQk*Q-e3k
&\$UR05%Ig<GDpH[re\`O9>)]AT4E43Y,lgmqp'M:-EJAP_V/^N!%F\0_KeYMT`f0]A06<E5:[
p-:a'F*AtBgZ]Aab(iUPP]A_Qf/+"l5emaFPqK=c3mrTs+Ys>(GuFhDQ%?L)R=V!'H6FejGAA3
ibddjCK[F&!i=oP$T9h*oUb^NIJkZ*nC/4RH<<8-CENN*M,BD8Fa/[E&=u$@BFmZ=-aH`X03
bL")["Lg[+]AkY=!4qP06,6M+18Eb3)6K_0IW+r*'Vo>)?m?:F8.*aO>s]AAOK!g'bsi_og,!/
&>;]AI:;"7j@S4p[aE%VlrMqL3[QE\)i]A2IH;hRtUOO?141-7QHle8sBSYG7?gJSHLB(LP0T.
$6o$cl]ACgo[,d5.o1S.OO^j%A4@a7$rLS@tRW:X&6f;UJ(*`I]AXlb#`;t^=L$&'laT_p%>G0
SRt:VMrR'/PW#=Dao(MhbcHHh^C,BHH67Xn7lmfcPY[pht@&9c1e4&Ui3)V]Aop]ANSk#$%LQ>
Mu!g<;XEMZH)Uj4/(gn:P[jD:VP1]AGfaK26m8#iTn7-agGXJNjb>?EN8-4u_\?c?!KV2a.^>
LDPZTRQU?M^VP+%7*dCdT$a%iM((P44kKO\\(i,.;+^Z94-Yq`)>jsG6ZgWlP:=HHHh%Ku1B
%q,usXR-Sr54u>N;'U)?G-<`M3re0Oc*=tqb*]A'_.MD.g[I.0HSnNYK">OFWL!Lao:/t@?%@
16aVj^Efgm=S[Kj&LBER75,^P4Dc?1DVJ0Z[ZAAtJA+Z\i4)T879<Z[bW\5D>;#)bT4"C,'X
!mhc^2i<gH<:i+b\@hh/'n0J$EB9!k[OZ@O0chgXdj02`sN47:3'R=Au"c6`QW/2.h75Z<\e
9Z:J2l?6g%+i`*-R$,N2)hn>mf5OKcR.,(I^d96A$$#pGNOFAO$h?E%eCtVb+]APY!^p"Cn&\
]AcbhI1%Kdof9[@k9:S]A&`(A1C[A+[5#!0$Dan]AolF]Aa*IhW-1pCE`<u_+[U]A+WcOhQq*]Ae5s
fCRrb/F4/q(V*=+8S#bqDgndbmp.5t`-jejFug8q/Kr_QO2r[jUO\m(i"[NmHYe@H_G*%go&
^.sWYXo&`=frLFcr(m]AK=KP)t7H(:XC%D.eC7oWj$pn]A26^iN$YNg.]AH9Ab[Z'l0/^LP\rDu
Yj"P)18?0hZcoo48I>SPGTb*3B.i%1*o!:ZF,^hq+COW$eK^lt2FFPK1gHj3i#b(T=rI[B;S
"T%F3c>RAP%agDES-]A?L3<]AoO)CfDg:e_2.R`mr1`6<(\D";L.:YhWU$q1#]A&*e.okht"K%6
"n'=$L[?R/5X+g0?:;!+rt?`Q0)K*g((;QaZUe\CWT-P\D;&gL'G(<3_[A2+GLT")2-Q>D'q
^WbX2k[u]AKjb:pmT"bC?LI7L*'l`YJSm1l)_p<DO';IF'Pf?+*eDCVCLl.KL=MIpcOgg]AnT6
4p6Ei45lAa=@L[p`h#O:6TuPunQF/Y9XPL_lV32]AoJo>mdK<muEp8)[U"^?.HK>n's9dY37s
3ZbJk>BFp??&3igR!&RBAFRu)ER'0c^^Mr.rAoWbZNA=oa.^"6\bbn92*V$ZeTjMY^hdd#XR
<"Wp%C2$G_27i"d"mq1U_i[&`!3t[C&q#p&>&L"(crKPn'j9Y.5G[XH$9A$8sP'4LVaS74qG
nt>6Rd%M7i0IW%o1=Oh'<toSe7:SI`<)SUJQM6XDdn#?n7u@QuqD:GE6KfD80!'-:g$CgM9G
V>Us2Q'`NHD0SbH-.p0=SpNDeN<ZSsqPtGk(133Sm\Tgbk'd;UNsSEU:)]A[n'H-^X\a(L6nR
Kp1Tlr,!W`7k[H`g[Mb)J>khdk;bY<!q4""hUMk2VUuPFYtH*$5B3JU-Z)\;HN6R!VL^4j(B
Q2HuIH_"rsd+*YqCkk2g4_D2T"/>'u&NRiHI$5B*V+,_r*R@j5D2&R*KXPQRRbr&8&>7i(0O
qt*kG,t+9E+#/8KJEGa2G5/Fl$Bbai=Q/RU1'1//F66=%?:u2*IK8&RH9"<lCGL2$B1qWD]A>
\Vl+P=)kYWKaFp52k.T2o-l*KZ49i7AQE>luAUpc&;mgfu$/7Gn32`k<0jWUCBTLls4gU3\[
jF$1LR-*Cpk//3qqdV&kSf'G8=c:H%IlPu`(52i]AH94ST!4a/_AG=./*8a.q+\k-M/Jhl]A$a
=5%S#+[@AT@Z%,l*f-*?(u5)s49l/_X.%5;%"\C*ZZrkgt9i]AGQV8Q'PXJs5fNLoP3;#U"(7
:6-OR$=T]ATj]A)XlR0BA,5orI/\#4mdps-OgJG*I$Q5]AQ8r3%c@eEcqW.Fag#f1cNRH@$'o+V
!FQkO:K1UPJ;mgd'j8\^N<Ud"H'"Q7$E_Vah#!-3H65q!<Y9aDm4WQ0oHJgl=hVqQ41POoQX
`=mT*-GPjF\r/a16kIZl,W(17[3=V,WHRH:ib%lt`PmCg(od-D=+1jd91'VD]AcbaY9l`H+O.
Iqo$'2J^\VYH61b8D7D`Fa2'Aq"F+MaM"KmY<&_4C"jjpCU]A3-LncmSQ2UUeT3CK!D^A*?4i
2ED-[j-\0#E&Ff8iD'ZD+k+O8?r,g4k7OnCrMeR_Y4=At$r*hB(\pBfk?WdHsjV\B-N_9pA/
XZf&*1FFJtt62gqf]A)nW'$I<:$;2Ahf2fl\L-+%6s%sBX#N@R-"_<8t'XQ?5nLcEhEh6H=07
6icF\\6UPQr`J_9(%gNB[U/UH-);Q+>]AR..`'%>d$]AtSP$gOP,?6YQ$+<7ph2YXR(+@[]AHW7
E`FdMiUiRj?p8i"5Hg)jmm8"gRt6e#A*/r?D4>gG-=2]A_c-ib;Kh2!J=u:Mn:#6<$L^I'#1X
P,_Nrd_/'*M!'-H#^N7?SQ;.>-7Ucn!aBF<\<V`Sd_T\/;X%6QKX;H(Z,6g78fl?K#,SXpA.
S=%/:/7CBNpDCMB'AO1D^9VYTAV_#k3q=%n\Sh9R'BA86=lNmN(a9(i9Kh"I9,[ZUFWPgmP8
(nk`a?TL"a#"2,b?X8`MP9KZKWI'sE7Lh\fF[eurHW9XpQl^&UWmuaAd#JiS@eC$-5]Aie\J-
SURrNj-EfC$?k^C7Ho?3(Bl9"!PcXYNd)s@>,=sk"Ump6_;/Ri/N]AC@60>KfDHsjARNo>WPf
q7<g`oa_S/WT"=uu(+Gp<limT#"0s0TP4+MY$M_`NlAqWQC?!rRG6r=_/gFY\!FN:I>i0I<u
M7//Z7IWI%-hX8UNJS;i&8Q+s]AKs;*@p\9!E&dHQ9c\KEa20U<qSXYkU7;QR&Y1j.G^a#VaN
d_<1\X!VF,^ppI5#d"Ti2S#S!\"d!2oA4[&kSW[^;sC)+8-!l?G8bbFb&OE)KC.*kqo^'.gL
6Hi@=d73>"bQrC./PpI'o8;L+\'5_h7BK9p2_=G@K6>\bF[4M_jiZ37+c>CQkhj+Yp,9&A\1
Y8<]AdaU,A"h"\@JnhU7Xi=G*K[M=n>bmX*3la.mm%uV,X/l'?FX="3m[2&YPN+OD/,^HcQ%_
$&#2GaU)R7_R`hL3"q?-n9`L6_W41m^/Y%s1@E*)38UMdm`;4/dJ)H]An%?2eOZ\p;\)dE46+
bGB2M(k7PNNI\RA^S"gh/k<=`(I0pG4I,aQIb<pGb]ATTI;0OEi7i01ZELYfiY[]AqphpqmY`$
N,l^=Lm[?siDg2Z^dsluI&=-4Ik[NZp+%;/]AJbcAY*<BFYL3<[>rk\EB9oNgGH`AkqH+"H!D
XblpF*+\X=g(<7gd#=dO"/V9Uopbpm^,!bM(#SH=N(3_4+8noXLE%5icTSk]AC4(o"(IJ;#N)
@e,sZbor;@/_#GHuujAH!5MLkH.$ajQK]AJoLO)Ir"i!tjcUJ;.$:)m#fu'*7PRn=@X*n34?T
;CF7/EbmML5Q4#o%e+J:W"[\#"dVG&S+e3C1Nr<u.+.1>HQKsq\"QkVC9827a2&)U;928;^Y
Ho[[I]A3Y/!NbZ2[`_eHoi4'_IWqM(h]A8k.u#6+AYq\Mp$URDT(#5'QYZ$T!U+*Ah9*'GJNM`
223Nc1gVACWB$<Jo1FV?!t5hjNsB]A\6d_f[m5"rW3mfg2^-((WFP&@.i4t:*j+KoZWnlAOMY
Jgd]A=c;N,,/=Y]AiWhE&BGqf(Ysq+^eN7=<K]A-h1E>EDr4@cfl9X]A1&7Q4!FG.Seug=jM_jGl
$%lB2u2Vk%@Q<.A9hsjD@XQgG.%)<e0f"1MrA+O&mip*>H#HOrG*NH#<keJ-W[f1@u]A9;d*J
D#!Q"`q[g]A*sZZ]A(`U_#7Zb3_^=)-l('eT9dRK,TRnQ'pDPi,0AM+K@2gE.VWS]A.T:]A09N*b
a2M!s2K)BlXNrHbp]ADbg-n2q9Yi/NaIFNU*P/P0iXqL<J1!;,5Oi+q^Peslp_E/t)FrI'iU4
S",8SOSI/sYZ2=$K4pVG'X<^Q$CC&IhISf+n%?c>o#kriRn3co0bN[T:L:V<8J"!a3LHJ@u@
54e6sDcc1tV?t'>aeR:gH=TmMke2GH!WeA,l/:AgtM[?pm;o&HCbHc]A#EX3q#.T1SSnX(=tV
F@P4C#<<\a?<V(F"+38Hf^s6*q*PIMh$(8K2,4*-$a-&T2:iG['PRlSG7*5J?\+BgOL&.oB+
MQA'Kr%pHui0q%s%IATA.n):#'meBK(&-s1*B(`@Ouf[WL6SFQ@Zg@,]A;(Ecr.?_7'[Y2e1@
rXaS*mc0+EQdo0!io8s&PZX.l\pT3@["Y?2l=Yeg62,TKn_)H9fofnr.[OCW_bPSl(7'hBMI
&S0&tJUk6\r]A[bqsXfZp,&4Qe#_q-E!j`]A:7Iq%H:5?]As0HHrX_U`2#Ngf9u%R'^L:O+$WW.
uhs%s!d`=f#9WrjT7kgAtZ93K1E@%$/^`p:paGlm0a+=t"f:G>ZjFt$dB%r\PbQ1'PF(07_6
=#2-9jn_]Ac:W<pD9_&H7\Nq!1j+;!-_BfBqAR>)$CDA2\UPc^\(_E%]A*GM7i:149/]AOWiY%U
S]A0>%n9F'i`qSLeODD[']A26u#aLq_TXhr)=Y7^AC?g%t`#lJY;h@SNiIN/'Uk3\lL(;Mrug.
,Zp$l,sPFW16#:r;A.BhfBY+Te9qt45:rNB@L=GP,PfR>Qt$D+\*3>b-=]A[86YB<GA)37^[d
Is/[4&c7^&IGT_$o<NILs:U(#4jGQ-^1:q!ujqrq]A)EC1<\Jr:O1UK5QpulTI>3R\;DQ%5Ag
`GIsYOgA"F.Zq9&e@%II"Hb\nm:t#9p>>;[H%jI'b!;Z4mmuN,u6ZM5l?cie<W=_-+m190n5
)+l#<LKop;'g@O\%SLkhE9DgZoO'_mndJQ[FQC&%j<3/`?tGX>W]ApN+0+Xom8nNDl.6"i7Vq
"TE#9`RO^!"_A\?.Yb5:iQJ8h$B6C=4fLR1i#NmKR&:XRaJKL3D3LW*Wgq+I"2euu\d-4EU_
LIN`fRt?IL(YM.f"[,[`QXk=2Ml*([NN"BF/NWI-II"B58YQ#=bh`LreERD9m',@ri,6E&KN
%gGr\2Z]AiLk<9_s$jrPP1\`guDl*Kb=.dr(QqY0l\a+d1h/pge@ML6+fnf[21N[)K<"(7ER"
073j8"&&8f1c"%IJW)L>R[%kagq'@6'D>1.G`uBYbCZ)<J&tELH6kAk#>RKcXTjL#T?_l(?:
37IlOBq$`,C4?<ARNroR#V7IXg*-59GJ4t/S&22S.?L^\@iqc6'79]A5(]AH8b&^qXri/:<eE2
KAOX>u!)3nM&YP'I\gg[;YT)1V_6Z2boVAaWl1$s;N=#n?+paOhZ8QGZ+5nNJtdRJ2fIBC/$
5,P1^76N)=*@Zo-'j3'2oEgG?;S#.70mD2FS]AZEHc)`8f*0>HB)"KK?*%5aOlocO[2=Pm\L"
gHeGeS;34kJrrD`4a>7!+oUJF5H75G5eTR`2(pNp!ctjsGt%3^O).E/"6h>R_YT]AN.$M`$d-
.<Z,PZVlq:eqjCg<H<%f;<KEHc#o.'9[-l3,95hM(2t#1":.j'9)f,)R5#]A46J(ni=Jg9kZp
$Y*jL_`]A*'sIdB[d%0njkk/_RME7G#.Zc%dB.8oA`%lo_"B<cbsT0Td1$&Wb7+(qd4#2^gB0
CG1A5HA)bV7m.BNYEXe@,`F).[&;&:t%V.r'XnsuIdXTZ0Uc".$O;VdSLpW[r4KO+-Lc-d=M
KYHUcLD]AbU]A2_tXfE#E$C#"q$[YiQ0d7dD;`a&7leN;[Tf+Jc_9t-Z9Uts;q?l(c9lGuDb@q
[@@b;6]AQa`FT`Q:GghdG@.^OhjAi=`Dff'=0SJcZ1EGpV8#_jXaJsT9JjLPL$?m=c3-qW)S4
PYdt(?FBMcb32oFG/2-ofrlHT>7U]Ann8\plhAccnne;7%2&L`Ct[3aQ>oH\^7UQ6,G7ag_dQ
6A(p;sVJET2(X6`<MV:Z0kal=1+AsOM'Y.e)]ANqC)Yp]A:%I.VXiX"d8]A2nLpbC/W&:W3'V)B
UP:tsj$C$]Am+@1bn@dbA:rCMkVl<s?.[Ed`mt(n>1l"]A<J+[mrLIXrih%$LUP*.oX"ql-Y>/
?!5)#JFPO,3$LHNOoFb@#,7"k!@PIIhcfA]A;dr`MF,)7:%%iD#ho;pMY_(1+&jG#5>`1*(CA
N;be-s#]AMqNn]AU;3TQq>j0sF]Ad=GD;E@9)SEI#=>@B>kaUbCDM\<H^^(mQc/_iJ$amg:MS@a
>LmGXQdi=pD_:qA)Xf#4-^QOBO7Xe0REF:KKSkqf/m/45)+=<-ii+i\LE5M(@^CO$:#WpK8n
2<BXhA"`fkJRVkbk"0EIR44k)eStQ:,[J5L^")jnlLC7`/Sin0KSsVGb,"gYdCo90GL+G<bZ
=WoDg:?d!eS?noGO1Z!W;-cOOm^D"nR,cAAgDS*HX0)LfUg,iXZoYa+33cD[%1PBf*3'P_qt
+'%P"q]AQVM2;,+jUM\cP&EXA**=TWI#df9o^n93jKHKSNZGLCY8*ACO]AfM#=9!hE!'2=8n4Z
$l-@%;:dD:DmDp(@08M4<aLg?]A=o+J=bgXKZpp&:%9h'_aR\*;9Ai4S4hPQM5FJN[$ehOqq$
/=)q$UYbX^X)sJ.aX(>@'56!F3JC3^RiL[FZH<;XtoNK9>C";JC[5H:BE9b,"#]A!<$_7S0cD
oQX1B+\R>8jiBjQFXbtD*;M]Ao9AbCFKjau/b837;T@%36q1A96h^%T0'H*ipS7#tk*s#/EM;
pFd&us+q1IFS#,>m\cZm(#;o1e"'"Rocq^2_m^S'U&/U\]A;2'-k9?s#`E9Z>3/T?V('F?l$0
XES5CkksW,kfl\rjE84mBAFc*RSU[<P)Y<B/kA_l$HVXNAZn/E!r3"*iETTZYJV8QkrXon2Q
Ti!RG]A*+Q+p?k,f98jDQX4<hrS)8d>Xd((.I4-"3kEf`%fWj&;/8?mE.6k@9.l:aIN[_D>U>
V-HL%oQu]A2!lUCI;mN(Sg$@TjTE!mf(-7JgbeTP6@5Rred"7&!&>bd@<^K5^0H@,P%ZOm"*7
b+kjgY'RYT<KQ:HDj0keSGn,:n;A#:uqiobh2jmU,X@1Kfc;94;D1S`Y/bFpNhY,$K7S.i<a
U;E+g/3c1,6_nKEDQ+]AIu%&'N*Nltt5l(ZC%$S>>UGEYu;Mb-?G(&HJ2sgs9e+1B9/_(U3:Y
r*Ur2EP=.+!q_.nXZcB!YUf/WnOU7I4&PcD6didBn=\>2HA@0)Q/T&5-E(b:8LpW3N4M(@8Y
_OB.-?Lj%;Mf9pRH4'H8m?W\0dQmleG7p%\oZ:Q?,H".!GNtlW5eN"q>C((J=)?gq*m]A+$%t
X',jSFPT%sjHig9RdoHPSHuUqP(?S.@1%_781#`XGqbnaNaO>]A@[PmtR%MK6:a<"Rfee9)+J
T8U/f,3YGg_D*Y6occ:gJ&PA-'-5OR#IR[=N5cCrFp[O^4?o(Y,V8k!&EBd<ma7LIr![s'$@
&kV=qCp\XKV%K,p"JCe%N82/f5::i]AJPo<W*<A*p=sC.n'"iMA1$?n4dG7jK&LVBUZNL)bM>
*]AOZ@[GYi/=6F^rXlJoDP(XYI3dM9[3X'XXKQfU9qS<n`q[gY$ki(fiU#EU)m&^L^j"=#=L]A
tpL*orfi6Z;GE?_cU4S?B8lr:=u0l?m]A$KdSRG<rBi[L+CA'm&/ftA5r)choYM_FS&Ach"o>
mc$N!8BE_$Z5g(5kcDL&]A\IH<'U`6smB^l*.+!fsoiOH-.'uE&%%mS]AWp,30RqhpOpp]AHC0\
:lhG]A6JJkl@A3Dq=<kG,(PH8PAJRCXa]AUf\"BM-m4PJM-#(uIji<>@2U3lRb>#OZf?O%r(Wr
k/m"2N*W5QP^rMAt$=2NBB2g2/G06^<=DJfjC2HRu9'"!Ym^XS@oKJ*.E?h2#[m1"DNEjnTZ
7s.`EAiA;E,[jTc$[SQbD.U8"86LfB@\;U79$?sgZ%Kh6`&u$+^SEE^g3)o9d6Da%.pDEAT8
K\kl`0r^9p_31%fIu%IK@=E$g"piifneZ%R7`kdCH&iI/UfbWF5O#bAti^7Gr=+X'\o&mf.7
u'"9F([->1amMhh/',(NIl1Ma@hfik>7@?GBLZn[G%0L3k8q3p^/MuC4*'RSgH@YX15DZ7FR
48I5rk>@WeW9Q@>:PB-c#CBe;U+A!Sq"VEj2hqU>_#PB87dE)H,:(or69%[@eL#!nNR_GJ;E
7j/CmfA[_s&a<fjo-3c<[?:gSkN0hZ+L?HeOrF-J!JX0+7[c2U`>(6i(&.fK[bn,C?2nd!VG
J$cZGX06B^eHWMOWXg0+r\p&&DgUm0$52/#5!BT2?,-0S]AC_8lDThS[s35*M4'l.aqi08YeT
#lbh&e,.#aCV!N?om]A@;p[98[>I)C9O.kV5)Gdb5+Vl@Gm6q5?:`V"<RF"=kSJUou1##5Bd*
s[5[IP=,LaLTC2-0(J[XtYXg7'<T!E+?u0l9c&iGSqNl`]A;?shfhHStVWW3jCe1m@'IhP`*.
/r]A.bhZe":tBOWXZ_7X$L=N'.95[*D9qOp+2AqtV(Vcm#e.#rlgHW5ikqZs&Z_4`GP1nLrsY
&?bfo(+Y]Aa!]AEZ#KUG2uoABtj>m^B-Sl,NH2qX9BC@4E_N^M34G':mAXpk\uL0db=!e/o=bk
PRb\>>3T%_&3VS@n[g8Zc`[3[&FiFh/=s_6\^,$WQ*khiDh0=ias[3`0DliDo9;Nu=F.^j&>
$*OS28;=fV,O7T7#TSrY"/BV>)_<LILq?Ss^/\b*M,X^M0nO=k;mFn-dYeQ+t1uHMLa.9s`h
=b0oG&[Hd,lU9rSIo5M[o9Cg;K"j-29+ha?+HMt&";+AZ-_GX!GJ_P9?XeQi^f(Y$*Ut5Q/4
5>NY2T[c?PP-lr/Hr6FjKOoO0I^#+PX@G[3dp&NT:t2XCTjSApha-p]A?j&Ls/'ei5GMVq-Nu
^O-ns0^IGCaDqO^WBCrq)@pXN0-8<^++puo?+:5E1JP8LT)QP[[@LspCK3=C,+oaaDCja>&+
98?Vie@43Z@-FejraWt"YB1rB?a:e_Y5Z'-_@ekrN'I^5DPI0C1tU&'NDqLO\JCJ@l`V0#iQ
R*r9A.p_m&O./6K*tg;U0"=Y>TBIgK[FWch=HQs!_@,0*=#-0:\R-f774OcUV6fYaY0tht`%
bZ;SoU?k4eom'@I=10AD_")"hCH8e:lE,c2/YZY=ALB$)[C)2<T!m4Qe/i03arlm)P`]AJ]AmC
;0>8K_S0DPUf!6UYULe:hZWm44=P>''?H/9?M?jfX-lFH'=*TJ,>\EFEnrd,!,@*Q=pRq7Mu
1'cPWCpqYbo)CZ2<1?hnqM.]ANYW?i@/Nel(tN;4+%Tk7Qb&nT0@0%X;^j`8(.=+:VPt0[b!E
Y![nYr'7ucY$PJ`+[=FmN;c]A:0'eFffB&6'D(t`lf+P2"9n7?'+*`AhOL^PeEBa#M`#AqSUl
(3\eXcIKX"eY#T>LohpQt81GO>D1~
]]></IM>
<ElementCaseMobileAttrProvider horizontal="1" vertical="1" zoom="true" refresh="false" isUseHTML="false" isMobileCanvasSize="false" appearRefresh="false" allowFullScreen="false"/>
</InnerWidget>
<BoundsAttr x="0" y="0" width="475" height="535"/>
</Widget>
<body class="com.fr.form.ui.ElementCaseEditor">
<WidgetName name="report1"/>
<WidgetAttr description="">
<PrivilegeControl/>
</WidgetAttr>
<Margin top="0" left="0" bottom="0" right="0"/>
<Border>
<border style="0" color="-723724" borderRadius="0" type="0" borderStyle="0"/>
<WidgetTitle>
<O>
<![CDATA[新建标题]]></O>
<FRFont name="SimSun" style="0" size="72"/>
<Position pos="0"/>
</WidgetTitle>
<Alpha alpha="1.0"/>
</Border>
<FormElementCase>
<ReportPageAttr>
<HR/>
<FR/>
<HC/>
<FC/>
</ReportPageAttr>
<ColumnPrivilegeControl/>
<RowPrivilegeControl/>
<RowHeight defaultValue="723900">
<![CDATA[1638300,1828800,2880000,723900,723900,723900,723900,723900,723900,723900,723900]]></RowHeight>
<ColumnWidth defaultValue="2743200">
<![CDATA[5410200,5143500,9525000,6324600,0,2743200,2743200,2743200,2743200,2743200,2743200]]></ColumnWidth>
<CellElementList>
<C c="0" r="0" cs="4" s="0">
<O>
<![CDATA[50点未出库]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand leftParentDefault="false" upParentDefault="false"/>
</C>
<C c="0" r="1" s="1">
<O>
<![CDATA[车号]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand/>
</C>
<C c="1" r="1" s="1">
<O>
<![CDATA[零件号]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand/>
</C>
<C c="2" r="1" s="1">
<O>
<![CDATA[描述]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand/>
</C>
<C c="3" r="1" s="1">
<O>
<![CDATA[过点时间]]></O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand/>
</C>
<C c="4" r="1">
<O>
<![CDATA[ ]]></O>
<PrivilegeControl/>
<Expand/>
</C>
<C c="0" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="BondKB4" columnName="VinCode"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand dir="0"/>
</C>
<C c="1" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="BondKB4" columnName="PartNo"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand dir="0"/>
</C>
<C c="2" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="BondKB4" columnName="BriefDesc"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand dir="0"/>
</C>
<C c="3" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="BondKB4" columnName="CreateTime"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<CellGUIAttr adjustmode="0"/>
<CellPageAttr/>
<Expand dir="0"/>
</C>
<C c="4" r="2" s="3">
<O t="DSColumn">
<Attributes dsName="BondKB4" columnName="BackColor"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<HighlightList>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Red]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[Red]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-65536"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[White]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[White]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-1"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Gray]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[Gray]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-4144960"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[blue]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[blue]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Scope val="1"/>
<Background name="ColorBackground" color="-16776961"/>
</HighlightAction>
</Highlight>
</HighlightList>
<Expand dir="0"/>
</C>
</CellElementList>
<ReportAttrSet>
<ReportSettings headerHeight="0" footerHeight="0">
<PaperSetting/>
</ReportSettings>
</ReportAttrSet>
</FormElementCase>
<StyleList>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="200"/>
<Background name="ColorBackground" color="-3342337"/>
<Border>
<Bottom style="1" color="-13382452"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="184"/>
<Background name="NullBackground"/>
<Border>
<Top style="1" color="-13382452"/>
<Bottom style="1" color="-13382452"/>
<Left style="1" color="-13382452"/>
<Right style="1" color="-13382452"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="176"/>
<Background name="NullBackground"/>
<Border>
<Top style="1" color="-13382452"/>
<Bottom style="1" color="-13382452"/>
<Left style="1" color="-13382452"/>
<Right style="1" color="-13382452"/>
</Border>
</Style>
<Style imageLayout="1">
<FRFont name="SimSun" style="0" size="72"/>
<Background name="ColorBackground" color="-1"/>
<Border/>
</Style>
</StyleList>
<heightRestrict heightrestrict="false"/>
<heightPercent heightpercent="0.75"/>
<IM>
<![CDATA[h0XEPdchNkF/Pt9W3N3o;Q$%i9[c[hgdfO=9s#tch9t(taaJpn;qogE/bdKE&dA#8,KjA4"\
"!$PS=]AE&J]Ak`Co42u^A#A91\^Kd5M&,L4IkRskBtVMI*^,o46I&pJ=D6OY?SIGGkT@\MsJr
B%pc[443An#i/'M!*jT[Sp5u\Z1b\[&d"uM/S<iq;/qrbZD*@TXrNKNC$FWQE@Kl24f'C=/Q
ZJ@;\e7j&/('Tk.I-DnF2+?1:d;:(@k754\jm4ud?u41]Alb:CCDsbqf&MI3<W`kpFZOCcf:k
/#+q*k'`lIXq%D#uoLOG3rn*:eAChr&%aF&d6@_$.)Z%";t!9e,i"-!tPc72)?fX42W`OQu&
N,V*jHIZdE[kIPVBU2]AshnJ_c$"c2d^DP3,?7$%)B?Q%o`r)qLBmj;oSN8&VT'F58^670Uf0
k8ISBt=4buH%te@_l8$IEJ)0MK)l@8NX_9jJSRf@H`toe&=+.,aHqT_&W>M3*_^q$Kr_8P)d
_?!WIu4W21obgm268\\LmTm]A))=Jsrk1D;!P-MV]AKMF.Gq`p0t2CNuibI@-7kJ&\o"XFiFV*
=`S`h@=GRkKN+TC$7^,'T"tX`LdboZk>j69qDB]A#ST-j/i6/t",P^%Kpe1-nlRPV;EVS[=(]A
%?0G:Q*b2V7E[o)3Rm[g]AVipcK`Vc"%+C/nQCBm=h_1eqe!nc#:0X:,Y1bJFB+Zsi0rG><ZE
$8J.<@AMo1&Sk246WG6%KN'Q&\S2*f?i&lW79Ei2(]A[SYW9QKgf[qi&cu&eb/9";YQ(bu1C^
a!M?Fg<%RUhhR^nUN!#e'2NdbIk#mdul!3;.WM+:VD[*RP,R_05m*@FA-lWZD2I-=qbuGG2m
pj0g\&kY!Lg5Q^E"5Nh^njPA+u*;O5?VqeF#k4=rYHm?b7fSd>(=mAe2]Abk2.orX#]A+&C_CL
TY3B_klhqV$eu^]A&]A$Je'Dn*%A.)^Y($@48)_L(9o"%25$AdW'#&da,4K#`D="&Dn5SDK!')
-<Z!m`03u3;XQHk@^3mY!)OlcHM>4[Wmf";ZqZA?A_!+#Xq]A")`7rE!8Wc*M_-)"'=N^OP_3
,cg[KfKWWn3E^u;-Md6@)P%):9^G>CaV6k:Su&TVd_rMi;T?X3S$XKbkb!:^3RL;aL2X?8;u
e'Rqsgfo$(W@>@#>9:4EVS`gW/A!dMdcXj"s@\*jPQ`[_*[rb;%Od5!,9U/tIlrn49HX4O!_
.`d-"n*1k6["H@9CR[rRtpG*2)4oipUlPtVb4>,m454[lno3UU8S@\81n-!shJ`9Hh+Yq#[m
!97(e'lZg)Z[L6BmDH_$'AtiJ4LVtf^6TZjG*kuZb0Y-S5U[;q.`LL=oD[!]AK'_<$UWE7Nkd
&!c0DGrnV8KDh(-MPkMaqk=Ed[Ls$CPY!5?4T:n(huRgU$4'#mXciFs_,S@^cGSoZ_):Tg*E
2/$'Ie'2+Jqu21qn.&k(7H`?=#h6OcmM*4RQPk_H%:=cC<60qn%DS5PY?T\M_js72jc%c*Ge
Ad!cGgc!_?D'Bb6`rkScg4+).'"@ZMLE'DB+sD(P#/abb#/i62$BN+)_KEBuHut1@)o%oLSH
-_O\e@)HM/"T``U(bs9-m!6d&oXV0ZqkWpHN54s2ub\B]AO2J(:HhX6CBBl34REH-Tlq?2$7>
c71'5eb:$8V3T)-!f,W:Oq2Znl(2WA=@lV=X:=gNrY/@!)fejb#:(CSZi8qJ9'Mck>@jSG6?
Bj_#GgU*o."fD-#OBaW6e?CX1j/Ccs5+/FBE4kAG#r"G'V$HHl@spA4iR-1iHc(9;Dgmu/l`
&eTe5EZe1+Pi^d>edEuq^"ugT3o\^6-sep'b`FF`QqOAR>n*c!`%]A[-MHC1^)I,SQJb:B6<%
?*cFR(\`rSBJB6SuM&W.=kp<hBhF`.4?6gh7lr(Hh`(?UV<4)EFm<VG97Q#_uC_+b.SdX\Q7
8dNj:g<Z%eZ(B#<<HD1u[%7<G2W=<-,odNh]AbC6K7H+QY0c^qp;GlKVtb);e^8@#]Aqa((B9E
RD@47'#6)&"cjPU#L%JEkS/A_rdHr\nHN2i\=o&]AruoZ=X"u<QI+=C_t<5)X`Me!<;0Hp*S&
45.*?S=]Aku!?",(Cp.N:VT)e9Boqpk#Z2SJ(*foNYZ\*0$JfXp0(&CK-hW:WjEaO:0ZWr+4\
SaHCXYZX7;j]Ap^0i%6&&Xa$"'UhG*S&quDRMt(n;^cQpnoY!66h$*2FK-I,?P[kA?&W3ErH.
\maMWqs-hbO;;4osjm1D]A7i,O05]A.*Kg-0#GEO=Z>M7G,C+PrhXFiVk'ETij2DddDGPW&)O_
Vf)fWlCjpG8@k:!^EB&s<;b)15`/J=t/'`p&.f+VVmghC(M8gB9jI0LWBZaaP6aq7UT'`kJb
c97m:bIfTr.ObSgGoRRc0.1Q#%>Gj4aGCDc+81/UgF-goi'L8cTFq?!bqo\")&'.o0gRXOMX
aJS\s14OE8XTepZO*9`Z2*XWC!_&Lt>lR%Spp-a[^;$Oop$Q@"N[5etalNRD@rqh<_V>j5L@
'!f5;V^,II=s3p9,%'[*Z2XfmcO.tF1-&@P%=%#-BJoZ7b]Af/8Pm@T5.m4l4o+T(K#DblPPd
r<-638aOUm!hEV=\c`k+s!cpe`/OVP1^'Zr7?5^p,b)Q_g^@fXmHAB`$Wdduj`.V]AI;7,Zg&
]A^[Xp4;NIE.UNtE8+rL#pa!U/^AW\E18tCi96[X4@M-VNI`P"I)0t0XFi0A%14AV60ZgUGNH
Gs6&RSO)X2;D#V-7S:ABoQcig8]AM=Res@H'8?$/7-_!?c:qdUo9/N]A^W/g'1sX.i:*rH+'b:
V+el2O;MIS;g7M2JM*2F)Hq`$[((AJ:CdoY(4p`?\O"rJQ4U<%es1hQpIatd12)_nY3@.\GH
adr7baX]A[eo`-9)`[cFid!"$h[gLIgY7W;1_UeY]A)PLn3-s=-RiA><pL?.,5)%rM#UBjH=Z_
liR;fF?Rp,^8-#LKjIrC\(YgUP2=cL1+:#tQ4BVmoq&g^<RF]AV3Et4r^6Tn:(@bfagagpDNS
<UUDTeriiI.A8hP+Iuh`rXs7KeSX=/25JZ<J77MAf.1PA49?2nCR4f3Xc-*5aj1,l\:pX?PF
8s6nL.?d/<Bof.0fJ6['AC]A3Fj0AM2ce;X/H<S=/m#k;@X;P?JuV2p@\@NE^^lQRZMpOBd<&
ubQA)WgB6ZA[o/Pu/c`+IgK6T<pQ]ARJ0EI)u@9pUIY8l*0+]A&'&Us3MX*\]A1.E'DB?1"j81n
BXnU7S`F.aGX0Uf"34N"Uc14T0nXK6WcIg5<d!s/Jg1J3IEH__(2[7Y&N#qFb?HSM4/1qh_M
nP8o_D7Ld<so_?&&tH^$dlo6\?=soh.P_aY\N-OYn]AX"ilN`<RH-4hSB3``BMD:*"7d>a:D_
]Ai6Lhm,KB5@`sbAC-VH=f7ZD8RQ4l'lj"#DnEeVuRGpiTs-BK0lBn*+4^IPh^eE9C%X>U$Qc
2M]A$iRHfeP7fTDFgt8s,EShZpQH)$4!.YE>Cs<!*RUA%]A!XX'k,&A#SFSM]A`onm;DuB`_f)k
0VWZF3'-/E5*X0At^k?i9smf;c>cjE`%rf/:c]AlQZ?>lf6VE::WTnGP_h0.0XnrK;+o(jRT1
qi'^[.$ri$*F8sm[3#Vl5K+W?V<WR@p^)=Q8Z;;c,!`0K7d/7@"*)\5%;*cMGK&`3j1aVMAr
98<QWHirPK@5Gd^._V`p=d'B9N\4A(RP%UdE-9F*H\G?FcTs<SlFr=n5Tc28HYE17)\P0!Rh
![Y%]AElZc)uj0aVMbCp5VDV$;$ldNjNcV9oUP,tR?GdlUY8@eTQ^,;iCU1),?M`oFb.>A``$
!ZsgI8<F1(('?l`H/(*a+ViJoS`AMbu<\gC/72P]AA=SPANG2WXPQ'Zm,n^*KcU/9qMK,eiY_
F4%1tim3lU()&3(ggrG$TXSEI7>8lcjq(6<HBn_`d&SIWKBc=-#hG,<8J==3PuPZJAG4557E
s%^"i-i"qH80NNLR9EPApN@!Tcl-Ea^$Za_mLMg>$QQX22OA%PG']A6:'_e>Rj+X:T:M96FK@
E8+\_7d/?df2PH5=c0h%cVYim/:=H@X2A]AI6)XC#nHB+j'%0a"R[sC'3"'Eng3(G`6&D;rZW
h>.JaU&II:eRtJW,3/uJD.7/Xq4-<_O_U!*kS_5b&^Ge(=HhS`=NU;/9BjAP?^WL8ee"E*eZ
"JF1Y_,%6W^B)+2-gg0=SBWLH[BO;Xtq_uS6)R2gcip6rb-\AQ&CjS;=m?^:]AkHY6rWCY"=h
F4[t-[)O=K]A3d7aiVI!lM;1JV.G.mMGJ;Z9/l16QZ9DR4SL6:UuGC-0\=ktFf`c7XF*r0M/e
'VTar_g3iJQ.'?hq%r')'(e?f"/,t<*FpuJK7T`D?I'2JhQB)sO717f6AT`aG.PG(nh1/;aY
sn]A%Ef:(mg/@fo)h@h,@Y<sVeM$KW"d_@NJXS53<-eiUlNa)/g";eOZXl.cq.&!-C[!Oe]ABD
f:2@(f?'BaWUm!jq%im.[>:'!b.R<IQDJuU._'noWqDIUYhg8lXV(4A=8O.,C#Y3E./\^WW+
MX-h(MGGH=TYRQ!1)aT"B/1q&kUab=/;u5>q9GNb?`bX!7B4r9-pfH.FHlAa+i[UE,cE/XZ]A
+[(QrWN/5"gMpG`gI+WMT/bKLFg$ikXq^@Kq/c%&De.>UJ'cj7N>V+/c!Mg[5Z[RBgb/CkR3
H!;2*dd(9J'[_;J^?rY!/nb7(17W)[^WdW:hU+%Eo<*G>c_iM0O3ni;S]A!7Hq83Bp-NRQJd]A
]A2bgj[HJ(RP`H&#iCrP(3LR`Ec^c3W(kjou.\7rd4mdZ.;jRR7#sqq3;P6ER)pIQcmkd4<04
B.m?elY[!O$M-&RLi+UX/okZC[^>A;pfO[2so0Q3L>&)C=@kNFJHJJsbX7Gasq)pn>MF.RJB
"=@^S:LD[IU0V`;JuqJk3Ie.WWFXTi4^.rYCF$u-M(U\-%7$g+U,2%>4S>!gT@;K,:WmZ'>*
X:It]A1QB=j,Tb*PdP6FRmj?c[4[0J"GBc]AnK<*DB.%VKNCKL-,GmDI.Ul(<Q/-Uh:]AhH#\=/
>''IrWp%'_dZJF:!kf+LF>mo,nq(.[)NH[lfWBNoSVJ.>-iWh,\aOLV#!]AiNITuMj,ZhQ;@b
4%\s.e"0>c/&(03ehC%^*_:Z-0VHd5$iHmrIn`rjW[49,RmElp_.WG=qorkt[T@1.qX?-#_j
6NGRA4^Rj"@I(eB$LSu))7?2]A$+IOX:oPm2^_>oS/:p6<&TL6iUOZbW!9$b-"%i/g*2ICkk%
a4FDPBq:&k=0a('tr>WY%M,rX;1f:6G@=<5XIVD>,U)Zil_@BV%69&,B5k#TWts+">F.FAC)
;pk;j68ALc&^A%#J9(,9+3Kn^,\>DF]A2R#'!8.3";X:8(n@bYT._:k7'0IN(06A_SIU4hR_n
436\J$Nd.u#KM(gM_qqb6NWfFb<2lg!GSh.Z?'o;+T!jfoo(JMnp&1I]A5Q%+1C@Z(70u`=/c
qRu:t:hqO!1%0Q.MPL1\)""?:(OGaK\>@.-TgG#)JTM*Dt^$2`W;^Rku@LMT%r,)/OC0nY!@
u=9*>Fr8dVL!&XA"\;=?O@AMn<-=iXaF3'CG+\00hQUtNPSP7"2D"O!e)ep,`eFCr^3j*aK=
DW(h*\;-$k%/2A)_7s=G845o6YLiW0T!>.?+u<a)=kj???"_-<qngkDX3MK9U"j);(U2L%QW
l0*ZCAmLRN$c<kl*T,Ks'>N'F8'G/7[Vpqoq!]AN1tSZ62%K5\"]AW-JteZW@B`GJgM[!K5n-J
[4o(:cXNED,,CrF[Og\\rK-;_Q,=aaB)KUmaXJaV+hU"6nt\&;;56]AfXY0eN$QUD!K92PLPe
-4<%0>jt-3<\&RMQ<oGGg<e?ej>A_@0a5^!\i@q%Sq:hdl(SY9)I!\9AIFmrU!XZ+Ps%+6kX
YMtr@GeT+P)=bnXM#qC$f*D's!eBj2FV-hA;=.@Y=7A6UCE)gIMV3[@b9JGI$Y:e"&,LU)4m
8mY"H.BI<rh[CUHD,2B`Fb3D3uCQp(/ihGMRPlD@EU`p,b):r]A;8a4/Ki1Tc?Fh=]Art2F!oN
c`[8cPiojsT--H!"MjeF(?`U+=".aO-/^@q+Ac8^lL]At_9Z,s&jCm&?(r.'-@]A5R'BG,`jM"
gVKVdK2rkhL.gYG5LBR'pRA$\hu"Y"bUc&#fRm7D`T[$B2rY)ff)]Al>Q@m`K9V9>C0JNmO$5
NoH7oLJFWnh41lnd7dCte8+n=`nq.ZDRQ+]AmlGgGP@^&+?j#j-*@!j8T%1TrHKJ&&DPgf\]AX
r7+8XeC)YlqJbr^"!9"[W3&3\=/E<22I&]A4k3/@#BCKAe'Hh9]AmiO-pT)^![E@jK31s)ibFU
m;']A8ITO4VOB3>0'KF6X4<'5F[F-dd%ZWr)_I,5Q@nHb\%M=s857*\0%(Xs)\R]A<R/OL`GJ1
dqk#Fda#gqO*fQA96Ku'2XYUuaJ5)I7oBPa^p;>WBd5c_ZW7DFHt*J]Aa^mI(3i+.7H]A`46=8
L=F/nGsS)k*N$]A/9m:Ci:31L`]ArZOaLYp]A[YnI.^%cC:?X`\dtWVSbS-:Jm&[kD;WVu*o*E>
ZN0C=d]A]A`.!n>hjQ8pmOiqKTDOMm`Ciu6,8]Ap4oLu;b54<6">T/KB,,\/mJp%IlHVQBp;7$`
-*s0RJD'aqT4OsJIL(_@O2HcIJi.Oh6JB,I37FEp4I8>UXp-@25X2c5=$WY-iXW"t0'4jO12
e3#e!_JW5UnbH1!$L\F<>*Ro<!d.F"rc3U.mZOaLpdi"Ole[_^M^D?Er&&H"gp2[nlJ"FA>b
*h>ciUO!t5&/Q[)&j\%F/e-33R_,Quihi4>aJeo4,#VA^NDl.+)rAT)\Fc<oK!ZU*e?A`865
p-T:]A?m$HtDM]A0!=t[qPN:sOc/X-"WcB]A3CS(>JHZ9rMh".GSLph(+t9+\LDWcMc(.g2:bZq
LjOd%1kK5dVu0SfZnX%D/CMs.3V9[%)l@$k-qjCBr,HUl1k+A8@!<:["MgF1ZH"`CnjOjc*A
G=%YA`jiM0j/)%uLIC86jGe'RQJOYCQN"*HoIt^^Y`qNbJ"E23N-+h]A8bRVG2A;n[%$Nr9cB
uPml'E'SS(mr,/<9eYAaSjX>J]Aa[]AAXNqEa9t+(4V?]A9`:%q[iBFgZa&)+rFh!tT9u`h!UVH
9tUJ"26*O3`'Q?Sda=r5+'0:X*'1=:&I&3n+sr]AZK8*tTgt0eMc(-oFLb8i7lcX:je;%)kS>
?b%jl7WUSkN]A<%p0BYD]A9f4Y[:9'T9q6hE;o$[kD>h@iG,pfeQ6H_3o<JTMY!HHtsSS8<?G7
"P:UQY)6V_`3jE+u7;@r,d&ZO#F\IJUhRd56Y5dH5*J%oJ388->:q\%eGR3`Ep`aKD^<j;0R
ZBu_%#b73*/NY6;b4e81%[6'!o:4Y3E"<n$RV=WtGaiN.h`u5no".`"u&3PL/0C1LeJdk@E8
)`3S*L6anLEc!ri.V1hlnnR6@9URkeB:#&RpbICR3*c1Qu`:TBj9&Y#*`Gp#c_3GMJ%-g\*E
9iZ:O[j="G/-PqS@Tia1>9:+AS*%4h7`0]A#=^N.PFUOJdjKeZJKtHA)Q.V(8"q#7.+EEU0eS
8?Q.EjY$LGJ8sYkro<i*'aJdQNDm53V@lC5i=@*8/%PTleG`Xs#mCIlZ7rS@9Uc%70iKXj\4
3M49[#"WFIIrU8E[eMdLcj#Br:/ID\*K#:l/j?.s2/I^@:W+eGbIoRn1g<%@q-/&LR[?/b)4
J.J%L;U,6r12iruY0]A@l&<aAiga#Jq131_-5@^6RBMWo#TP(Y$C1RM-#0@+A.c%RXA@^lk:f
i&mG2%a#8U2e\THG7r&3'RRQ]AW;BMX*J^Y\\1C$4fEBfmNiN_7(+]A7ZH!pPn,#:h&)V&1Mck
s2E3B"SQ#s<u8t#GHe((19D)oYAR4;H\WpR=r0Y:tpU[s:0/Kpp%.`?6S7,mYUp\mh7B/,1M
_S4T$*Icu-jB[9h]A6!s3C:Bjq0_dbbeA<Gs4.i$9Wd6U'<qI`uF1]AaP7g.]A(;h.o%;(-goW)
&<dTRmX?MSu4`%?uGld9f*;_NA/o3.^u%cbluuk`saYih33>/e]ABF<)9=KGe]A3GG2>=/Q/qL
&JP$N5_@5+R^&WJ$Dn@Jco6!.0Cc/l&3>c<^=UoG_Qr\`p_i4F&]Ar6DN-<Otc%$#(=e<3fDj
g<@>rA6prXKA&>TqpPCj-;18/\E$-%nOLEPD`A%@o*TRT7)^Do,i:(Fo!M-A<&lh?='pHm;-
Yj]AfHlB:C86[DYPPtMr_<SWU1AuNr![`a'O`1+-#)W'h72O+/a@.l.QngUa_cq.Z&1t@B(CN
BF.3e\D@X7(DO3lJJ"Pibm_tb*#MMG<fQVu($huIZBYT6nLR&D)1LeUnM,:Y,0$If0/q)^?S
Si/m3D5_`qlQX\W@DgE[!aZpXGnP7:,7I&6>n322V-,"jY8r#%^6XqPT'g)TVc@iK/Y'abK5
F%UhukG@$0RG^`Ei^YK?B^FYM$'u]Ae3'HgbfVnC7&It=93i0C-AC3i<00n&Uud!#%-R+/MF/
C+%e6CJ,V?6+1#]A79Z#I.g7<!M?i''+=LEZ4=1r;PjndDWaqq+YDeM:ig]Al[%KXdG=N<u'Ir
B[B4#Da^R>]A_\aMqoU(E!S9fYj0E@'NZX%"UoJk3W?i`/58Y#q8RGaaODg03PMH>SMbbY52g
OMg$r)LAHjn*>%\mtl"m6.%(HBICZd8lEG:f3h,@>CnX`I#,#;Mo5`'@EmX,a\S_CD'tgZNc
L2Hqp&"&L+3ZM-h(h&K&`0%Ye>YKc2aZ;If[*hBq_P5ls#Q[M"WFUXW&&Z'%]AQ3Df1RQWe?Y
ACKUm#Jo=aiWqfYK0%]A\0(<^O=(dD`Co+*ekiV(,r[.Go#iop[,QKiDV7;n\+Y26pa6f%F<5
5<:E&rgXVhf>42iM=FH-YDM+aa8]AMS"B;(8($bMFpB<N;uB-.5Frp!R]A*P%*.Ch3oZa0^g<O
gL)2U!#Plf%q,Va9N.<L=@2$9CY]A+;`V)A]Ac(Fleo;!0)2e@[%K$MqjC54e2,I`jL.;<HQB,
>=FL`mYsJK+Ao5oBs\Sa/6LE^q,uJ>Nn)K+gB5SV)/L]An^r/juW?>200XS>0NbeJBC+81"F&
3(EiM<r54Q?/n=[&GPf-ua]ANW&&\GJ.G"mq*VW\HN<q;r6Q_).r0'LG.$Vbp_DEaB]AnJ`66]A
EP>OSV@NLe#9gLJc#=Q"!Ag`27_\Lj\^28'NgE-oc4/8YJ[R^.<dc]Ab4'[[.ZG11B<PROb&D
99766B2;)"WI*J-\EHZ5H7U;Ub#40OH,t@eLl+B$LAb2:N+bL[^#m*>@Pd)-ni><_H,1uNFq
8U@Bn)%p3qDWPO[3fq^/**$,uj0!b>b)g[5@Za&Qi;iar<f/2+Z>XmLiHX4=Ep7^O!?SC66&
goD3+geU-.5'e^L_a6H:=epM'+>%`cB_#.m5`Sp&d^b*Eofe'm:1uFt^6jZRXYIbBf>s]AWEh
7!.TO:>LQ3>QhkSX)RmPBWWq+314DD0g^Wtcg`7ZZ=_2]Au2bH6!l$clu`RPYcP*"?`nl#?5g
qQ8TSuHb]A2YA#>qj^J,T1Vbu?Vgs/.^=md4_c8*hB`flC$hP_X.U:]APOiCo'n3Pto+l6qQL]A
FNJ-dn7,aRd@I$I5-`J3bkE>`%3b@=8X-E$17X(Ii0di!p"Di`(IU,71Kt5E_#_&2T6mmhqB
)ns(K3ZM8[&7L8>51#E3>k>Nbdff:L.U6T[$]A"U0^,!@reB2JQ05\c17G^5B&#WJk#O?0Z\:
"Se5"=*tFFX=[r(1"1(J-Cq?KZ$hWs@=-^s#=FjDL;poI8)FbbKGU-c,Z>*?&pCkfij-42.k
mI_6X[tq]Ad)rY]A)mj.Y0DptOalZbf2:4UrcJ<JGY?C>o!S4TLcYIG%2Jko&g>SYZJ7[Jnbft
bFRof'PWp;PaD?*g'q+?c7^IHBjkc/d<H6n&2\TdlF+`mcGZ#Bc8(5sm!uCC"oRhCHEce^DL
->g:LTD'ONm?dYgJ9&/GL%GB@slVK;NZqFZoDtIG(1pmXe!]Anp-eQWWcugjA.f_:B?PO7Cs=
<kGsL=NS*f_?SQd*^fIt"kIg)tW]A.q*!@gMg'>L.O^chq[``-,ARP?]A:;):5P%Ai8ku+^NKK
+?2T2^=JD*\$&2'TCNZ_n;AAiW>btGD%;'d,#&)A5V7kaUs@jXJ<d;nBVDZCmmZ.Fo2ci!j.
eN":BsEB`@^spk%<\rl(bsjDn4Ma>)#eI,GZD%q7JaNE($8*h_m0EH4gVW7;a:P`AO>YaQ5Y
+Pj)Or]Aj4J(AkELEr'M%(cQ&m(eP?V2_^H^@6JW<SnbcoR*ieEW:\$q/2tpAoE.ACkftiSuU
Gd%d$bdRJ::2@1BDlXl=cpt!e#`,Wf*$[T<PIQJrDSmC1)T)l#XG(%3_ac%<e?t+9K1=r@4B
s#[4&'D/DUkJ+S!<kH"K\@_9\t%$\,TQ^3?[VO'dgCa5[:a3h,`h.GEhP5F"IR.l#=`3t!cE
h7e3,M[=KNhP=QUZK8!f5+21;'=cdIjpUSLkQ3HpBYEZd04ipqS,Z[iH,OOp>/sW&Oe3UnPP
.+:Fm$P?h!-78fsc#.f2W!MlKE.j\>>L2g(.'8?eZ3WbgPoQqQL.P8)'2^df1`n@!W"hdACh
c459bnTFZK,.VMK`G]AD[.pnUjoF4UVs:CCk??.QCJ7f6ON]AQ2Sn)2C<=W@B)2dE"WoOtQ0;D
Wc#^((r#7V.\!3P<#Fbii&d.\;1>+B&4$]A-tpa+NX)phAbc$b`%DEkD4gL5;P=\-n?-PYCtR
Oap]AldQb=jUJ`:G&J9$6l"Z9E5L^a?u9#EAmQ>:*r]A(u*fChBjQSUbRZ(<,=]AUF_;S/"]A[nS
Sf9.\H60@s%mc`&9)Ha!qb#!E>tTeg([2Bjf\I!6/,b*ILJ]AR<olQVa7\5f:4hD$KI-nm_h@
rGs`9S4pb%bl06lrsQ@H')t-Z*c=S#$_k=Cpn1b\=gI8'7YAFPV7%4(S]A/5<'uFg&A>r,nNh
Ge@rggE5DpN);H+SBj7r6)B=uuZ6/0[V&<U2'^[.>AIIhY^=eFhI+hY#%`[qIZIGQF;4Ag/.
P6,qe6M(am9MdH<cn_$Z:rVpQgNnKg]A<@(\r),jSb>jlJfJB^cFG`_C6W$S*m0=t>'pRC9EM
r%i7i&M\TMtaVY"Rpq(/X]ANG[@hUkV$tnSr'c=g&ZpjskND?W&1"086^39^efJQBM=E5"QD"
Xs:40aY&Q9P@D\m*KAtYTrk>36:BW(dQqT]Aae:p3[]AM?'aaB/#'>s5$*guE-e0&k.A%Mo-mq
=CWPQcWd1DMVVr.<eAq_79sW!S7/\ULKUl\T]AFajb\$($jA1K*O$>']An91(P;m.l,+-_gJn2
_%H#U9Zi;?`ViB/Ga:&5C\T\)FX"*mm$Z5\),rZ2mR9@ALImR<>lL#+b[,D4Kq?;om_Y4pc]A
Ii1+jqb=o"M3+nL6<F4(t3iRO_tj8+cA?hA9tO^E-ccJimFk6NL)(ZgnAhHb)E0]AP-TW7B83
$%RonkZ#c]A5s]AXl^hiLdAF&Q2IB6*CZn\c.PtML0(kSqGa@!n($YA'?P/=/Qnr0N>K;f(2H)
RTF7b4#7?p?a@RG_b+bQK,kT[4]A1Yh*D!a5N7<U,dKCK;l?%S%rT(&V*?(#FrlZL>.$)?ILF
krD<b%ku.T[$PY+N94@g7:9<NfLPrt-Lm:QW0_mLZYWmOa:;_dpoCG@m@Q.cqj+ijA&.IjT)
6J392dTU<(P_gNCqOS\2cFWTcq_iMWSH7+s4$6"o*RC>jcB5o[7fOFik,btngTEn!VAI?KrZ
Odr4nToD[<3b]AGa6I<]Ab3pj)H>rBP0!8n:C.UN0(A!Z;P)*>HeTj'Ymk2k2pA$\_kp-7gQhR
CB..\NA*!A2I0SSpm?:8C%n]Ap/`72OJ?CkI)V.i+p>@S77.`e9J.N1ae&,>ol/4C$E!G=b@P
?;+)V7$+fXVKmps&i@o40g=P,(61UC&bnF.oh3TdpuLDH)]A=>IXa-qNT&Q=]An+F''B?pY1B=
SOc'5d%4p"5G#bMT5:`Q5]A&?qJ[q3#-\TJVmA8Fb\qL5f3\pC:VlT.SM,n(fU*V>Jd;ER.\1
3S5BZG9'qprfG9'B74b.UiqVRikg4["(Y)!)Gd+5tYQY"GN4O/.'2)cWK\UuS"&E%/coB5*]A
W]Ab!4RhDV3KtgZk`,Y'kDt"F*2!=XO50FP,DC?u&'OQ05FY^gN(EiJf>Elo8$Y]A&<sfM,4eU
3k%5mm,kRIh!E?IZ$(Zk-J7Z\oG=p6m*qfLO\-0U*6kf[Gt&0ZOtr4;\YQ>B3Xm!L_#A&2.P
d]AP"Fi+4OKlmTV!_T3[-cCpSW&(@sF['M..YkXMimceIUTpH^fjoe,b6^j)9<4)#'0JsF@A/
CiB;FK,5n3jjJfjeEAl+qPa*tR-SC+V:fKY/FN-"A/r_tnT.!]Ac1HPa5:q_1:a'?>c@=qPnp
CIU^>iYd\0/T]AXe\Z+]A7jo!K<I[0jOSVJ)d+1e:IH'?C^IU]A?CT2.,6=fsHaN++JV-I-&6+#
em.Aqn;u"AX'k.m6^@@r',38Gd"YR+.f@o@BF:4Ia)pN/aCUPNo8^bWQ>I\?^*L4+r7;p[7Z
,*&,b+&p_$\@Vh"rk]A.ZiT(cf`(W/$>*]Aq%YsnEkT2qf<]A^DV#7!OE[0Kp-M1IVM4ma#&Tr9
OR6r5>V%<!Xe.?FlQoZQ!qYSmb(RZVGkcWkcP=*Z%.AaSQ0XJ`_69,1mIolc3Ctt@60'R&+X
Nt61EG$J-T)LDdD=-6$%hu*St^h(>c@Y9=C*Y&^tDg#`E?gF.VCnWjP%2EL8RQnEdrO2")\K
_.XdOq@Nl(e48Q/ODAq1A>Qqd>gX<Y1eD:ouFI6a]A?)\c;!Cn_0bQ7?/%Klo^+#qBj.*+Lgd
6sKT`3P[r\gLg[DDX\UGKFikpD^+P>?7`B_\:%<X=>uTR(0:6(g.rP1E/*&m2<X'IC_%Y[EZ
L1qCFLSs6'X%C73$E:<;Xq;L2%-hLkO)njAG?_$Q<)>^LOY*;i3I>lG2l=cVY1`opU`OM\_7
=<i<i,_R\C#-sF%$-2`"("k50aCB/jai&?J5[fnP#Z)>4<G6QkUXJYBo\;q5nUT3rs6B*'.%
9*@>_bnSL#na>99%c7&oc>"(KVl0&ZP^)%TE;1,HFm0b#m2%+^NZLg[qr=AVjpeT7).\C?l\
-I^jdrV&(4kR!c0VLDr0Z*p1?TPqO/K4aS(KXW^`&aUOh'nCd\#H1f`n[g@Y?',l2g?he&R]A
tt_C<.ISVI^/Vl:#a-T]AO%)%oj@+lJ3]AkE@km\H^O//<rSWS^2]AYN_NnL.ZI[p>tp7_oWrf0
qW)1%83a'1NKL50pN'0BR7pAAkskh]AD(p^.=Z1P?)[M/MZQ-hk/^5PQ^mTo*i*6F19ben7J<
Rua[CfJ@O2f5h!>k+"3]A0_G%ZQS*Qbs4YSC,Ec&WHbY#Tgp``3s2!sN!ecP?@^N'.Lq%iFfb
D&GbB*W3@-9`Ur:/qe!o93E(qq>u!'e0B-KfG)f?f@X?QhA9G;.KJ+-8&L<KIE$PdDNC[=#M
N--#QEc[&q=\QA@!Yk5HDQba>BPK;OJ:"=c@?Wm<1KK\c(97tj32a65,TVcdEKu!ZVZ]A>58g
*`Vo."e>79hJETC)m(\WdLM>jC3p'KLYnSH_O0VNe\AX-#eK4Yj;db(.;-^hcqGBGhFe,/.6
OLi2a6u,+)[U3QPs$gq\)b?uQ7oA:fn`ST01,H)gtE*d[>A_5\phDT\m4-Nd'HBRo-IXgnG!
MjM6KOfqH+3fj6]AGX8R^=^I^-q>[neY<;`p-bNj0O8TKb6j;eR^5chYir\h%h!_#k8:AP`0X
!1Y1^j'563<d&k_Lm?I/6R2q`emuU$H20'P`qH5Ba\>rppS=UaO1.9rlRaFY#%kT)CGPd)O*
@ru".(;_e6Qg@3LJefT,fd;C0Np+MB;P.\=0eUW#cT4.V>?1#_d[,YN(oLa*4Tl(#$r#;$^&
^d'$+R=aQ6-"DdUcGul:$B@A;V)QT)ZZsKQjDFbgA03ap:!f:M^CZTduXMf=T:Ma2W]A%%/Lu
MTEHJosgR;*\9HVLW7R,86^=J9^5P=J/p3/@/+g)?:F54TPU\UOs"j5KtpGC<J!snL+J\5Dl
=RbRp+^;cP?S_#fW<^sF\b1?[h3oD3UOuktC&TGFYg7Y,VD,X,Q&ljS^Sbr6J2fJMpLk9CYr
8I\'>.VC<X\)M2#+28RqnMRhZSJ3eb@qQb/\MS12A@Pp;rT7K)koK&,!C%O3F=;U8;u'^I'8
^@l!##p8t%"=7M"QQM5j1-_Chhn56h0_WSA/+c"8P2dX5Lp+Zb<qrc*eC[&YE*NidZZ6k*Y_
(k[>el:2TS0E&lXW;mEF0d\"q3(VH[fNrqX^SiG`8?-[0>";r<r\lGrt_cgFr6BmjF_^IZj,
O]AkV[I2=6-*tc2fg`H>R%:2W5^P5\js4cd8qh1rk+AJ$+r_7%:4-%=2AalaC&*PB6qG,Br?E
^Jl3qruKLSi[OId&k`R!$U.2\Ms9E"r_&,tD4(NYO@0ucd4?"%>8:NPb-flIH.a`\9hltP4p
]AH;![=<DX[)O3aR*+d-?o$#CE<ja7pj!A#0qZa^O5,fJ>dn?:F'6dg7eJ[M>Ud>0&&;P)[R)
G;*5p%*"`.)kd^Etl"QusNK4"Xe!jj!Ja2F+M?jaj\tInt=u-9g\0m2h?;$B`6Gn<J47q>cM
FeQl;p'_7)h94"LTsSRV$=OY6-h"`'5hs1fJ93/V7>t5"Yc7,45RbN2#W/L>RtV\O>$,U^/$
cAP4B@@pOAQZX'39tqUIn+kC5AQ5,m3lSg9;&;a::4oJ=0k?HC/1GH;,4:GnOFJ?aWO8o%#u
_)M.(X\8\qp\m8GSUg@G.\+IaY3Grc.nZ#=EYOS5\Lb0Ilmg<g-(Zn2`7DY4Rhq4lmf'4LIU
e1^#KWNMXY#MGCYi!=j8Ij,_81[q<J%%Hn%DN_*O_[=@`b4s$?Oc:&V%7QjJ;CrAKL$n)?N/
%U"=bl0%e;a*M+J6\7SQ..)`KHe?uHMBSDRherVaB55F*V7jS'&PM0HQFb7B7g'4G^[;9a[*
r~
]]></IM>
<ElementCaseMobileAttrProvider horizontal="1" vertical="1" zoom="true" refresh="false" isUseHTML="false" isMobileCanvasSize="false" appearRefresh="false" allowFullScreen="false"/>
</body>
</InnerWidget>
<BoundsAttr x="0" y="0" width="400" height="535"/>
</Widget>
<Sorted sorted="false"/>
<MobileWidgetList>
<Widget widgetName="report1"/>
<Widget widgetName="report0"/>
</MobileWidgetList>
<WidgetZoomAttr compState="0"/>
<AppRelayout appRelayout="true"/>
<Size width="800" height="535"/>
<ResolutionScalingAttr percent="0.9"/>
<BodyLayoutType type="0"/>
</Center>
</Layout>
<DesignerVersion DesignerVersion="KAA"/>
<PreviewType PreviewType="0"/>
<WatermarkAttr class="com.fr.base.iofile.attr.WatermarkAttr">
<WatermarkAttr text="" fontSize="20" color="-13421799"/>
</WatermarkAttr>
<TemplateIdAttMark class="com.fr.base.iofile.attr.TemplateIdAttrMark">
<TemplateIdAttMark TemplateId="1776a996-7511-4066-92e6-0bbdcb36b792"/>
</TemplateIdAttMark>
</Form>
