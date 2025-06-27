FFmpeg 64-bit static Windows build from www.gyan.dev

Version: 2025-06-26-git-09cd38e9d5-full_build-www.gyan.dev

License: GPL v3

Source Code: https://github.com/FFmpeg/FFmpeg/commit/09cd38e9d5

External Assets
frei0r plugins:   https://www.gyan.dev/ffmpeg/builds/ffmpeg-frei0r-plugins
lensfun database: https://www.gyan.dev/ffmpeg/builds/ffmpeg-lensfun-db

git-full build configuration: 

ARCH                      x86 (generic)
big-endian                no
runtime cpu detection     yes
standalone assembly       yes
x86 assembler             nasm
MMX enabled               yes
MMXEXT enabled            yes
3DNow! enabled            yes
3DNow! extended enabled   yes
SSE enabled               yes
SSSE3 enabled             yes
AESNI enabled             yes
AVX enabled               yes
AVX2 enabled              yes
AVX-512 enabled           yes
AVX-512ICL enabled        yes
XOP enabled               yes
FMA3 enabled              yes
FMA4 enabled              yes
i686 features enabled     yes
CMOV is fast              yes
EBX available             yes
EBP available             yes
debug symbols             yes
strip symbols             yes
optimize for size         no
optimizations             yes
static                    yes
shared                    no
network support           yes
threading support         pthreads
safe bitstream reader     yes
texi2html enabled         no
perl enabled              yes
pod2man enabled           yes
makeinfo enabled          yes
makeinfo supports HTML    yes
xmllint enabled           yes

External libraries:
avisynth                libgsm                  libssh
bzlib                   libharfbuzz             libsvtav1
chromaprint             libilbc                 libtheora
frei0r                  libjxl                  libtwolame
gmp                     liblc3                  libuavs3d
gnutls                  liblensfun              libvidstab
iconv                   libmodplug              libvmaf
ladspa                  libmp3lame              libvo_amrwbenc
lcms2                   libmysofa               libvorbis
libaom                  liboapv                 libvpx
libaribb24              libopencore_amrnb       libvvenc
libaribcaption          libopencore_amrwb       libwebp
libass                  libopenjpeg             libx264
libbluray               libopenmpt              libx265
libbs2b                 libopus                 libxavs2
libcaca                 libplacebo              libxevd
libcdio                 libqrencode             libxeve
libcodec2               libquirc                libxml2
libdav1d                librav1e                libxvid
libdavs2                librist                 libzimg
libdvdnav               librubberband           libzmq
libdvdread              libshaderc              libzvbi
libflite                libshine                lzma
libfontconfig           libsnappy               mediafoundation
libfreetype             libsoxr                 openal
libfribidi              libspeex                sdl2
libgme                  libsrt                  zlib

External libraries providing hardware acceleration:
amf                     d3d12va                 nvdec
cuda                    dxva2                   nvenc
cuda_llvm               ffnvcodec               opencl
cuvid                   libmfx                  vaapi
d3d11va                 libvpl                  vulkan

Libraries:
avcodec                 avformat                swscale
avdevice                avutil
avfilter                swresample

Programs:
ffmpeg                  ffplay                  ffprobe

Enabled decoders:
aac                     g723_1                  pcm_vidc
aac_fixed               g728                    pcx
aac_latm                g729                    pdv
aasc                    gdv                     pfm
ac3                     gem                     pgm
ac3_fixed               gif                     pgmyuv
acelp_kelvin            gremlin_dpcm            pgssub
adpcm_4xm               gsm                     pgx
adpcm_adx               gsm_ms                  phm
adpcm_afc               h261                    photocd
adpcm_agm               h263                    pictor
adpcm_aica              h263i                   pixlet
adpcm_argo              h263p                   pjs
adpcm_ct                h264                    png
adpcm_dtk               h264_amf                ppm
adpcm_ea                h264_cuvid              prores
adpcm_ea_maxis_xa       h264_qsv                prosumer
adpcm_ea_r1             hap                     psd
adpcm_ea_r2             hca                     ptx
adpcm_ea_r3             hcom                    qcelp
adpcm_ea_xas            hdr                     qdm2
adpcm_g722              hevc                    qdmc
adpcm_g726              hevc_amf                qdraw
adpcm_g726le            hevc_cuvid              qoa
adpcm_ima_acorn         hevc_qsv                qoi
adpcm_ima_alp           hnm4_video              qpeg
adpcm_ima_amv           hq_hqa                  qtrle
adpcm_ima_apc           hqx                     r10k
adpcm_ima_apm           huffyuv                 r210
adpcm_ima_cunning       hymt                    ra_144
adpcm_ima_dat4          iac                     ra_288
adpcm_ima_dk3           idcin                   ralf
adpcm_ima_dk4           idf                     rasc
adpcm_ima_ea_eacs       iff_ilbm                rawvideo
adpcm_ima_ea_sead       ilbc                    realtext
adpcm_ima_iss           imc                     rka
adpcm_ima_moflex        imm4                    rl2
adpcm_ima_mtf           imm5                    roq
adpcm_ima_oki           indeo2                  roq_dpcm
adpcm_ima_qt            indeo3                  rpza
adpcm_ima_rad           indeo4                  rscc
adpcm_ima_smjpeg        indeo5                  rtv1
adpcm_ima_ssi           interplay_acm           rv10
adpcm_ima_wav           interplay_dpcm          rv20
adpcm_ima_ws            interplay_video         rv30
adpcm_ima_xbox          ipu                     rv40
adpcm_ms                jacosub                 rv60
adpcm_mtaf              jpeg2000                s302m
adpcm_psx               jpegls                  sami
adpcm_sbpro_2           jv                      sanm
adpcm_sbpro_3           kgv1                    sbc
adpcm_sbpro_4           kmvc                    scpr
adpcm_swf               lagarith                screenpresso
adpcm_thp               lead                    sdx2_dpcm
adpcm_thp_le            libaom_av1              sga
adpcm_vima              libaribb24              sgi
adpcm_xa                libaribcaption          sgirle
adpcm_xmd               libcodec2               sheervideo
adpcm_yamaha            libdav1d                shorten
adpcm_zork              libdavs2                simbiosis_imx
agm                     libgsm                  sipr
aic                     libgsm_ms               siren
alac                    libilbc                 smackaud
alias_pix               libjxl                  smacker
als                     libjxl_anim             smc
amrnb                   liblc3                  smvjpeg
amrwb                   libopencore_amrnb       snow
amv                     libopencore_amrwb       sol_dpcm
anm                     libopus                 sonic
ansi                    libspeex                sp5x
anull                   libuavs3d               speedhq
apac                    libvorbis               speex
ape                     libvpx_vp8              srgc
apng                    libvpx_vp9              srt
aptx                    libxevd                 ssa
aptx_hd                 libzvbi_teletext        stl
apv                     loco                    subrip
arbc                    lscr                    subviewer
argo                    m101                    subviewer1
ass                     mace3                   sunrast
asv1                    mace6                   svq1
asv2                    magicyuv                svq3
atrac1                  mdec                    tak
atrac3                  media100                targa
atrac3al                metasound               targa_y216
atrac3p                 microdvd                tdsc
atrac3pal               mimic                   text
atrac9                  misc4                   theora
aura                    mjpeg                   thp
aura2                   mjpeg_cuvid             tiertexseqvideo
av1                     mjpeg_qsv               tiff
av1_amf                 mjpegb                  tmv
av1_cuvid               mlp                     truehd
av1_qsv                 mmvideo                 truemotion1
avrn                    mobiclip                truemotion2
avrp                    motionpixels            truemotion2rt
avs                     movtext                 truespeech
avui                    mp1                     tscc
bethsoftvid             mp1float                tscc2
bfi                     mp2                     tta
bink                    mp2float                twinvq
binkaudio_dct           mp3                     txd
binkaudio_rdft          mp3adu                  ulti
bintext                 mp3adufloat             utvideo
bitpacked               mp3float                v210
bmp                     mp3on4                  v210x
bmv_audio               mp3on4float             v308
bmv_video               mpc7                    v408
bonk                    mpc8                    v410
brender_pix             mpeg1_cuvid             vb
c93                     mpeg1video              vble
cavs                    mpeg2_cuvid             vbn
cbd2_dpcm               mpeg2_qsv               vc1
ccaption                mpeg2video              vc1_cuvid
cdgraphics              mpeg4                   vc1_qsv
cdtoons                 mpeg4_cuvid             vc1image
cdxl                    mpegvideo               vcr1
cfhd                    mpl2                    vmdaudio
cinepak                 msa1                    vmdvideo
clearvideo              mscc                    vmix
cljr                    msmpeg4v1               vmnc
cllc                    msmpeg4v2               vnull
comfortnoise            msmpeg4v3               vorbis
cook                    msnsiren                vp3
cpia                    msp2                    vp4
cri                     msrle                   vp5
cscd                    mss1                    vp6
cyuv                    mss2                    vp6a
dca                     msvideo1                vp6f
dds                     mszh                    vp7
derf_dpcm               mts2                    vp8
dfa                     mv30                    vp8_cuvid
dfpwm                   mvc1                    vp8_qsv
dirac                   mvc2                    vp9
dnxhd                   mvdv                    vp9_cuvid
dolby_e                 mvha                    vp9_qsv
dpx                     mwsc                    vplayer
dsd_lsbf                mxpeg                   vqa
dsd_lsbf_planar         nellymoser              vqc
dsd_msbf                notchlc                 vvc
dsd_msbf_planar         nuv                     vvc_qsv
dsicinaudio             on2avc                  wady_dpcm
dsicinvideo             opus                    wavarc
dss_sp                  osq                     wavpack
dst                     paf_audio               wbmp
dvaudio                 paf_video               wcmv
dvbsub                  pam                     webp
dvdsub                  pbm                     webvtt
dvvideo                 pcm_alaw                wmalossless
dxa                     pcm_bluray              wmapro
dxtory                  pcm_dvd                 wmav1
dxv                     pcm_f16le               wmav2
eac3                    pcm_f24le               wmavoice
eacmv                   pcm_f32be               wmv1
eamad                   pcm_f32le               wmv2
eatgq                   pcm_f64be               wmv3
eatgv                   pcm_f64le               wmv3image
eatqi                   pcm_lxf                 wnv1
eightbps                pcm_mulaw               wrapped_avframe
eightsvx_exp            pcm_s16be               ws_snd1
eightsvx_fib            pcm_s16be_planar        xan_dpcm
escape124               pcm_s16le               xan_wc3
escape130               pcm_s16le_planar        xan_wc4
evrc                    pcm_s24be               xbin
exr                     pcm_s24daud             xbm
fastaudio               pcm_s24le               xface
ffv1                    pcm_s24le_planar        xl
ffvhuff                 pcm_s32be               xma1
ffwavesynth             pcm_s32le               xma2
fic                     pcm_s32le_planar        xpm
fits                    pcm_s64be               xsub
flac                    pcm_s64le               xwd
flashsv                 pcm_s8                  y41p
flashsv2                pcm_s8_planar           ylc
flic                    pcm_sga                 yop
flv                     pcm_u16be               yuv4
fmvc                    pcm_u16le               zero12v
fourxm                  pcm_u24be               zerocodec
fraps                   pcm_u24le               zlib
frwu                    pcm_u32be               zmbv
ftr                     pcm_u32le
g2m                     pcm_u8

Enabled encoders:
a64multi                hevc_qsv                pcm_s64be
a64multi5               hevc_vaapi              pcm_s64le
aac                     hevc_vulkan             pcm_s8
aac_mf                  huffyuv                 pcm_s8_planar
ac3                     jpeg2000                pcm_u16be
ac3_fixed               jpegls                  pcm_u16le
ac3_mf                  libaom_av1              pcm_u24be
adpcm_adx               libcodec2               pcm_u24le
adpcm_argo              libgsm                  pcm_u32be
adpcm_g722              libgsm_ms               pcm_u32le
adpcm_g726              libilbc                 pcm_u8
adpcm_g726le            libjxl                  pcm_vidc
adpcm_ima_alp           libjxl_anim             pcx
adpcm_ima_amv           liblc3                  pfm
adpcm_ima_apm           libmp3lame              pgm
adpcm_ima_qt            liboapv                 pgmyuv
adpcm_ima_ssi           libopencore_amrnb       phm
adpcm_ima_wav           libopenjpeg             png
adpcm_ima_ws            libopus                 ppm
adpcm_ms                librav1e                prores
adpcm_swf               libshine                prores_aw
adpcm_yamaha            libspeex                prores_ks
alac                    libsvtav1               qoi
alias_pix               libtheora               qtrle
amv                     libtwolame              r10k
anull                   libvo_amrwbenc          r210
apng                    libvorbis               ra_144
aptx                    libvpx_vp8              rawvideo
aptx_hd                 libvpx_vp9              roq
ass                     libvvenc                roq_dpcm
asv1                    libwebp                 rpza
asv2                    libwebp_anim            rv10
av1_amf                 libx264                 rv20
av1_mf                  libx264rgb              s302m
av1_nvenc               libx265                 sbc
av1_qsv                 libxavs2                sgi
av1_vaapi               libxeve                 smc
avrp                    libxvid                 snow
avui                    ljpeg                   speedhq
bitpacked               magicyuv                srt
bmp                     mjpeg                   ssa
cfhd                    mjpeg_qsv               subrip
cinepak                 mjpeg_vaapi             sunrast
cljr                    mlp                     svq1
comfortnoise            movtext                 targa
dca                     mp2                     text
dfpwm                   mp2fixed                tiff
dnxhd                   mp3_mf                  truehd
dpx                     mpeg1video              tta
dvbsub                  mpeg2_qsv               ttml
dvdsub                  mpeg2_vaapi             utvideo
dvvideo                 mpeg2video              v210
dxv                     mpeg4                   v308
eac3                    msmpeg4v2               v408
exr                     msmpeg4v3               v410
ffv1                    msrle                   vbn
ffv1_vulkan             msvideo1                vc2
ffvhuff                 nellymoser              vnull
fits                    opus                    vorbis
flac                    pam                     vp8_vaapi
flashsv                 pbm                     vp9_qsv
flashsv2                pcm_alaw                vp9_vaapi
flv                     pcm_bluray              wavpack
g723_1                  pcm_dvd                 wbmp
gif                     pcm_f32be               webvtt
h261                    pcm_f32le               wmav1
h263                    pcm_f64be               wmav2
h263p                   pcm_f64le               wmv1
h264_amf                pcm_mulaw               wmv2
h264_mf                 pcm_s16be               wrapped_avframe
h264_nvenc              pcm_s16be_planar        xbm
h264_qsv                pcm_s16le               xface
h264_vaapi              pcm_s16le_planar        xsub
h264_vulkan             pcm_s24be               xwd
hap                     pcm_s24daud             y41p
hdr                     pcm_s24le               yuv4
hevc_amf                pcm_s24le_planar        zlib
hevc_d3d12va            pcm_s32be               zmbv
hevc_mf                 pcm_s32le
hevc_nvenc              pcm_s32le_planar

Enabled hwaccels:
av1_d3d11va             hevc_dxva2              vc1_nvdec
av1_d3d11va2            hevc_nvdec              vc1_vaapi
av1_d3d12va             hevc_vaapi              vp8_nvdec
av1_dxva2               hevc_vulkan             vp8_vaapi
av1_nvdec               mjpeg_nvdec             vp9_d3d11va
av1_vaapi               mjpeg_vaapi             vp9_d3d11va2
av1_vulkan              mpeg1_nvdec             vp9_d3d12va
ffv1_vulkan             mpeg2_d3d11va           vp9_dxva2
h263_vaapi              mpeg2_d3d11va2          vp9_nvdec
h264_d3d11va            mpeg2_d3d12va           vp9_vaapi
h264_d3d11va2           mpeg2_dxva2             vvc_vaapi
h264_d3d12va            mpeg2_nvdec             wmv3_d3d11va
h264_dxva2              mpeg2_vaapi             wmv3_d3d11va2
h264_nvdec              mpeg4_nvdec             wmv3_d3d12va
h264_vaapi              mpeg4_vaapi             wmv3_dxva2
h264_vulkan             vc1_d3d11va             wmv3_nvdec
hevc_d3d11va            vc1_d3d11va2            wmv3_vaapi
hevc_d3d11va2           vc1_d3d12va
hevc_d3d12va            vc1_dxva2

Enabled parsers:
aac                     dvd_nav                 mpeg4video
aac_latm                dvdsub                  mpegaudio
ac3                     evc                     mpegvideo
adx                     ffv1                    opus
amr                     flac                    png
apv                     ftr                     pnm
av1                     g723_1                  qoi
avs2                    g729                    rv34
avs3                    gif                     sbc
bmp                     gsm                     sipr
cavsvideo               h261                    tak
cook                    h263                    vc1
cri                     h264                    vorbis
dca                     hdr                     vp3
dirac                   hevc                    vp8
dnxhd                   ipu                     vp9
dnxuc                   jpeg2000                vvc
dolby_e                 jpegxl                  webp
dpx                     misc4                   xbm
dvaudio                 mjpeg                   xma
dvbsub                  mlp                     xwd

Enabled demuxers:
aa                      ico                     pcm_f64be
aac                     idcin                   pcm_f64le
aax                     idf                     pcm_mulaw
ac3                     iff                     pcm_s16be
ac4                     ifv                     pcm_s16le
ace                     ilbc                    pcm_s24be
acm                     image2                  pcm_s24le
act                     image2_alias_pix        pcm_s32be
adf                     image2_brender_pix      pcm_s32le
adp                     image2pipe              pcm_s8
ads                     image_bmp_pipe          pcm_u16be
adx                     image_cri_pipe          pcm_u16le
aea                     image_dds_pipe          pcm_u24be
afc                     image_dpx_pipe          pcm_u24le
aiff                    image_exr_pipe          pcm_u32be
aix                     image_gem_pipe          pcm_u32le
alp                     image_gif_pipe          pcm_u8
amr                     image_hdr_pipe          pcm_vidc
amrnb                   image_j2k_pipe          pdv
amrwb                   image_jpeg_pipe         pjs
anm                     image_jpegls_pipe       pmp
apac                    image_jpegxl_pipe       pp_bnk
apc                     image_pam_pipe          pva
ape                     image_pbm_pipe          pvf
apm                     image_pcx_pipe          qcp
apng                    image_pfm_pipe          qoa
aptx                    image_pgm_pipe          r3d
aptx_hd                 image_pgmyuv_pipe       rawvideo
apv                     image_pgx_pipe          rcwt
aqtitle                 image_phm_pipe          realtext
argo_asf                image_photocd_pipe      redspark
argo_brp                image_pictor_pipe       rka
argo_cvg                image_png_pipe          rl2
asf                     image_ppm_pipe          rm
asf_o                   image_psd_pipe          roq
ass                     image_qdraw_pipe        rpl
ast                     image_qoi_pipe          rsd
au                      image_sgi_pipe          rso
av1                     image_sunrast_pipe      rtp
avi                     image_svg_pipe          rtsp
avisynth                image_tiff_pipe         s337m
avr                     image_vbn_pipe          sami
avs                     image_webp_pipe         sap
avs2                    image_xbm_pipe          sbc
avs3                    image_xpm_pipe          sbg
bethsoftvid             image_xwd_pipe          scc
bfi                     imf                     scd
bfstm                   ingenient               sdns
bink                    ipmovie                 sdp
binka                   ipu                     sdr2
bintext                 ircam                   sds
bit                     iss                     sdx
bitpacked               iv8                     segafilm
bmv                     ivf                     ser
boa                     ivr                     sga
bonk                    jacosub                 shorten
brstm                   jpegxl_anim             siff
c93                     jv                      simbiosis_imx
caf                     kux                     sln
cavsvideo               kvag                    smacker
cdg                     laf                     smjpeg
cdxl                    lc3                     smush
cine                    libgme                  sol
codec2                  libmodplug              sox
codec2raw               libopenmpt              spdif
concat                  live_flv                srt
dash                    lmlm4                   stl
data                    loas                    str
daud                    lrc                     subviewer
dcstr                   luodat                  subviewer1
derf                    lvf                     sup
dfa                     lxf                     svag
dfpwm                   m4v                     svs
dhav                    matroska                swf
dirac                   mca                     tak
dnxhd                   mcc                     tedcaptions
dsf                     mgsts                   thp
dsicin                  microdvd                threedostr
dss                     mjpeg                   tiertexseq
dts                     mjpeg_2000              tmv
dtshd                   mlp                     truehd
dv                      mlv                     tta
dvbsub                  mm                      tty
dvbtxt                  mmf                     txd
dvdvideo                mods                    ty
dxa                     moflex                  usm
ea                      mov                     v210
ea_cdata                mp3                     v210x
eac3                    mpc                     vag
epaf                    mpc8                    vc1
evc                     mpegps                  vc1t
ffmetadata              mpegts                  vividas
filmstrip               mpegtsraw               vivo
fits                    mpegvideo               vmd
flac                    mpjpeg                  vobsub
flic                    mpl2                    voc
flv                     mpsub                   vpk
fourxm                  msf                     vplayer
frm                     msnwc_tcp               vqf
fsb                     msp                     vvc
fwse                    mtaf                    w64
g722                    mtv                     wady
g723_1                  musx                    wav
g726                    mv                      wavarc
g726le                  mvi                     wc3
g728                    mxf                     webm_dash_manifest
g729                    mxg                     webvtt
gdv                     nc                      wsaud
genh                    nistsphere              wsd
gif                     nsp                     wsvqa
gsm                     nsv                     wtv
gxf                     nut                     wv
h261                    nuv                     wve
h263                    obu                     xa
h264                    ogg                     xbin
hca                     oma                     xmd
hcom                    osq                     xmv
hevc                    paf                     xvag
hls                     pcm_alaw                xwma
hnm                     pcm_f32be               yop
iamf                    pcm_f32le               yuv4mpegpipe

Enabled muxers:
a64                     h261                    pcm_s16le
ac3                     h263                    pcm_s24be
ac4                     h264                    pcm_s24le
adts                    hash                    pcm_s32be
adx                     hds                     pcm_s32le
aea                     hevc                    pcm_s8
aiff                    hls                     pcm_u16be
alp                     iamf                    pcm_u16le
amr                     ico                     pcm_u24be
amv                     ilbc                    pcm_u24le
apm                     image2                  pcm_u32be
apng                    image2pipe              pcm_u32le
aptx                    ipod                    pcm_u8
aptx_hd                 ircam                   pcm_vidc
apv                     ismv                    psp
argo_asf                ivf                     rawvideo
argo_cvg                jacosub                 rcwt
asf                     kvag                    rm
asf_stream              latm                    roq
ass                     lc3                     rso
ast                     lrc                     rtp
au                      m4v                     rtp_mpegts
avi                     matroska                rtsp
avif                    matroska_audio          sap
avm2                    md5                     sbc
avs2                    microdvd                scc
avs3                    mjpeg                   segafilm
bit                     mkvtimestamp_v2         segment
caf                     mlp                     smjpeg
cavsvideo               mmf                     smoothstreaming
chromaprint             mov                     sox
codec2                  mp2                     spdif
codec2raw               mp3                     spx
crc                     mp4                     srt
dash                    mpeg1system             stream_segment
data                    mpeg1vcd                streamhash
daud                    mpeg1video              sup
dfpwm                   mpeg2dvd                swf
dirac                   mpeg2svcd               tee
dnxhd                   mpeg2video              tg2
dts                     mpeg2vob                tgp
dv                      mpegts                  truehd
eac3                    mpjpeg                  tta
evc                     mxf                     ttml
f4v                     mxf_d10                 uncodedframecrc
ffmetadata              mxf_opatom              vc1
fifo                    null                    vc1t
filmstrip               nut                     voc
fits                    obu                     vvc
flac                    oga                     w64
flv                     ogg                     wav
framecrc                ogv                     webm
framehash               oma                     webm_chunk
framemd5                opus                    webm_dash_manifest
g722                    pcm_alaw                webp
g723_1                  pcm_f32be               webvtt
g726                    pcm_f32le               wsaud
g726le                  pcm_f64be               wtv
gif                     pcm_f64le               wv
gsm                     pcm_mulaw               yuv4mpegpipe
gxf                     pcm_s16be

Enabled protocols:
async                   http                    rtmp
bluray                  httpproxy               rtmpe
cache                   https                   rtmps
concat                  icecast                 rtmpt
concatf                 ipfs_gateway            rtmpte
crypto                  ipns_gateway            rtmpts
data                    librist                 rtp
fd                      libsrt                  srtp
ffrtmpcrypt             libssh                  subfile
ffrtmphttp              libzmq                  tcp
file                    md5                     tee
ftp                     mmsh                    tls
gopher                  mmst                    udp
gophers                 pipe                    udplite
hls                     prompeg

Enabled filters:
a3dscope                deband                  pan
aap                     deblock                 perlin
abench                  decimate                perms
abitscope               deconvolve              perspective
acompressor             dedot                   phase
acontrast               deesser                 photosensitivity
acopy                   deflate                 pixdesctest
acrossfade              deflicker               pixelize
acrossover              deinterlace_qsv         pixscope
acrusher                deinterlace_vaapi       pp7
acue                    dejudder                premultiply
addroi                  delogo                  prewitt
adeclick                denoise_vaapi           prewitt_opencl
adeclip                 deshake                 procamp_vaapi
adecorrelate            deshake_opencl          program_opencl
adelay                  despill                 pseudocolor
adenorm                 detelecine              psnr
aderivative             dialoguenhance          pullup
adrawgraph              dilation                qp
adrc                    dilation_opencl         qrencode
adynamicequalizer       displace                qrencodesrc
adynamicsmooth          doubleweave             quirc
aecho                   drawbox                 random
aemphasis               drawbox_vaapi           readeia608
aeval                   drawgraph               readvitc
aevalsrc                drawgrid                realtime
aexciter                drawtext                remap
afade                   drmeter                 remap_opencl
afdelaysrc              dynaudnorm              removegrain
afftdn                  earwax                  removelogo
afftfilt                ebur128                 repeatfields
afir                    edgedetect              replaygain
afireqsrc               elbg                    reverse
afirsrc                 entropy                 rgbashift
aformat                 epx                     rgbtestsrc
afreqshift              eq                      roberts
afwtdn                  equalizer               roberts_opencl
agate                   erosion                 rotate
agraphmonitor           erosion_opencl          rubberband
ahistogram              estdif                  sab
aiir                    exposure                scale
aintegral               extractplanes           scale2ref
ainterleave             extrastereo             scale_cuda
alatency                fade                    scale_qsv
alimiter                feedback                scale_vaapi
allpass                 fftdnoiz                scale_vulkan
allrgb                  fftfilt                 scdet
allyuv                  field                   scdet_vulkan
aloop                   fieldhint               scharr
alphaextract            fieldmatch              scroll
alphamerge              fieldorder              segment
amerge                  fillborders             select
ametadata               find_rect               selectivecolor
amix                    firequalizer            sendcmd
amovie                  flanger                 separatefields
amplify                 flip_vulkan             setdar
amultiply               flite                   setfield
anequalizer             floodfill               setparams
anlmdn                  format                  setpts
anlmf                   fps                     setrange
anlms                   framepack               setsar
anoisesrc               framerate               settb
anull                   framestep               sharpness_vaapi
anullsink               freezedetect            shear
anullsrc                freezeframes            showcqt
apad                    frei0r                  showcwt
aperms                  frei0r_src              showfreqs
aphasemeter             fspp                    showinfo
aphaser                 fsync                   showpalette
aphaseshift             gblur                   showspatial
apsnr                   gblur_vulkan            showspectrum
apsyclip                geq                     showspectrumpic
apulsator               gradfun                 showvolume
arealtime               gradients               showwaves
aresample               graphmonitor            showwavespic
areverse                grayworld               shuffleframes
arls                    greyedge                shufflepixels
arnndn                  guided                  shuffleplanes
asdr                    haas                    sidechaincompress
asegment                haldclut                sidechaingate
aselect                 haldclutsrc             sidedata
asendcmd                hdcd                    sierpinski
asetnsamples            headphone               signalstats
asetpts                 hflip                   signature
asetrate                hflip_vulkan            silencedetect
asettb                  highpass                silenceremove
ashowinfo               highshelf               sinc
asidedata               hilbert                 sine
asisdr                  histeq                  siti
asoftclip               histogram               smartblur
aspectralstats          hqdn3d                  smptebars
asplit                  hqx                     smptehdbars
ass                     hstack                  sobel
astats                  hstack_qsv              sobel_opencl
astreamselect           hstack_vaapi            sofalizer
asubboost               hsvhold                 spectrumsynth
asubcut                 hsvkey                  speechnorm
asupercut               hue                     split
asuperpass              huesaturation           spp
asuperstop              hwdownload              sr_amf
atadenoise              hwmap                   ssim
atempo                  hwupload                ssim360
atilt                   hwupload_cuda           stereo3d
atrim                   hysteresis              stereotools
avectorscope            iccdetect               stereowiden
avgblur                 iccgen                  streamselect
avgblur_opencl          identity                subtitles
avgblur_vulkan          idet                    super2xsai
avsynctest              il                      superequalizer
axcorrelate             inflate                 surround
azmq                    interlace               swaprect
backgroundkey           interlace_vulkan        swapuv
bandpass                interleave              tblend
bandreject              join                    telecine
bass                    kerndeint               testsrc
bbox                    kirsch                  testsrc2
bench                   ladspa                  thistogram
bilateral               lagfun                  threshold
bilateral_cuda          latency                 thumbnail
biquad                  lenscorrection          thumbnail_cuda
bitplanenoise           lensfun                 tile
blackdetect             libplacebo              tiltandshift
blackdetect_vulkan      libvmaf                 tiltshelf
blackframe              life                    tinterlace
blend                   limitdiff               tlut2
blend_vulkan            limiter                 tmedian
blockdetect             loop                    tmidequalizer
blurdetect              loudnorm                tmix
bm3d                    lowpass                 tonemap
boxblur                 lowshelf                tonemap_opencl
boxblur_opencl          lumakey                 tonemap_vaapi
bs2b                    lut                     tpad
bwdif                   lut1d                   transpose
bwdif_cuda              lut2                    transpose_opencl
bwdif_vulkan            lut3d                   transpose_vaapi
cas                     lutrgb                  transpose_vulkan
ccrepack                lutyuv                  treble
cellauto                mandelbrot              tremolo
channelmap              maskedclamp             trim
channelsplit            maskedmax               unpremultiply
chorus                  maskedmerge             unsharp
chromaber_vulkan        maskedmin               unsharp_opencl
chromahold              maskedthreshold         untile
chromakey               maskfun                 uspp
chromakey_cuda          mcdeint                 v360
chromanr                mcompand                vaguedenoiser
chromashift             median                  varblur
ciescope                mergeplanes             vectorscope
codecview               mestimate               vflip
color                   metadata                vflip_vulkan
color_vulkan            midequalizer            vfrdet
colorbalance            minterpolate            vibrance
colorchannelmixer       mix                     vibrato
colorchart              monochrome              vidstabdetect
colorcontrast           morpho                  vidstabtransform
colorcorrect            movie                   vif
colorhold               mpdecimate              vignette
colorize                mptestsrc               virtualbass
colorkey                msad                    vmafmotion
colorkey_opencl         multiply                volume
colorlevels             negate                  volumedetect
colormap                nlmeans                 vpp_amf
colormatrix             nlmeans_opencl          vpp_qsv
colorspace              nlmeans_vulkan          vstack
colorspace_cuda         nnedi                   vstack_qsv
colorspectrum           noformat                vstack_vaapi
colortemperature        noise                   w3fdif
compand                 normalize               waveform
compensationdelay       null                    weave
concat                  nullsink                xbr
convolution             nullsrc                 xcorrelate
convolution_opencl      openclsrc               xfade
convolve                oscilloscope            xfade_opencl
copy                    overlay                 xfade_vulkan
corr                    overlay_cuda            xmedian
cover_rect              overlay_opencl          xpsnr
crop                    overlay_qsv             xstack
cropdetect              overlay_vaapi           xstack_qsv
crossfeed               overlay_vulkan          xstack_vaapi
crystalizer             owdenoise               yadif
cue                     pad                     yadif_cuda
curves                  pad_opencl              yaepblur
datascope               pad_vaapi               yuvtestsrc
dblur                   pal100bars              zmq
dcshift                 pal75bars               zoneplate
dctdnoiz                palettegen              zoompan
ddagrab                 paletteuse              zscale

Enabled bsfs:
aac_adtstoasc           h264_mp4toannexb        pgs_frame_merge
apv_metadata            h264_redundant_pps      prores_metadata
av1_frame_merge         hapqa_extract           remove_extradata
av1_frame_split         hevc_metadata           setts
av1_metadata            hevc_mp4toannexb        showinfo
chomp                   imx_dump_header         text2movsub
dca_core                media100_to_mjpegb      trace_headers
dovi_rpu                mjpeg2jpeg              truehd_core
dts2pts                 mjpega_dump_header      vp9_metadata
dump_extradata          mov2textsub             vp9_raw_reorder
dv_error_marker         mpeg2_metadata          vp9_superframe
eac3_core               mpeg4_unpack_bframes    vp9_superframe_split
evc_frame_merge         noise                   vvc_metadata
extract_extradata       null                    vvc_mp4toannexb
filter_units            opus_metadata
h264_metadata           pcm_rechunk

Enabled indevs:
dshow                   lavfi                   openal
gdigrab                 libcdio                 vfwcap

Enabled outdevs:
caca

git-full external libraries' versions: 

AMF v1.4.36-2-gd7311e3
aom v3.12.1-189-g0ddc6630b3
aribb24 v1.0.3-5-g5e9be27
aribcaption 1.1.1
AviSynthPlus v3.7.5-22-g66f0d678
bs2b 3.1.0
chromaprint 1.5.1
codec2 1.2.0-106-g96e8a19c
dav1d 1.5.1-11-gb3c5848
davs2 1.7-1-gb41cf11
dvdnav 6.1.1-23-g9831fe0
dvdread 6.1.3-15-g786e735
ffnvcodec n13.0.19.0-1-gf2fb9b3
flite v2.2-55-g6c9f20d
freetype VER-2-13-3
frei0r v2.3.3-15-gb47c180
fribidi v1.0.16-2-gb28f43b
gsm 1.0.22
harfbuzz 11.2.1-115-g567a0307
ladspa-sdk 1.17
lame 3.100
lc3 1.1.3
lcms2 2.16
lensfun v0.3.95-1678-gfcbfbf38
libass 0.17.4-1-g582630d
libcdio-paranoia 10.2
libgme 0.6.4
libilbc v3.0.4-346-g6adb26d4a4
libjxl v0.11-snapshot-306-ga75b322e
libopencore-amrnb 0.1.6
libopencore-amrwb 0.1.6
libplacebo v7.351.0-19-g4ff55e0
libsoxr 0.1.3
libssh 0.11.1
libtheora 1.2.0
libwebp v1.5.0-48-g8852f89a
openal-soft utils-14-g18f861fb
openapv v0.1.13.1-39-g98e55dd
OpenCL-Headers v2025.06.13-1-gb79b358
openmpt libopenmpt-0.6.23-9-gaead38ae2
opus v1.5.2-121-g2329ed17
qrencode 4.1.1
quirc 1.2
rav1e p20250617-1-gc247d53
rist 0.2.12
rubberband v1.8.1
SDL release-2.32.0-58-g6a7132863
shaderc v2025.2-6-gecc3c48
shine 3.1.1
snappy 1.2.2
speex Speex-1.2.1-49-gb7f3fd3
srt v1.5.4-35-gd6d0e5a
SVT-AV1 v3.0.2-81-g926c94e6
twolame 0.4.0
uavs3d v1.1-47-g1fd0491
VAAPI 2.23.0.
vidstab v1.1.1-16-gd5a313a
vmaf v3.0.0-112-gb9ac69e6
vo-amrwbenc 0.1.3
vorbis v1.3.7-10-g84c02369
VPL 2.15
vpx v1.15.2-90-g686bf6f1c
vulkan-loader v1.4.319
vvenc v1.13.1-84-gdbfe2ab
x264 v0.165.3222
x265 4.1-172-gcd40fe75d
xavs2 1.4
xevd 0.5.0
xeve 0.5.1
xvid v1.3.7
zeromq 4.3.5
zimg release-3.0.5-206-gbde53c0
zvbi v0.2.44

