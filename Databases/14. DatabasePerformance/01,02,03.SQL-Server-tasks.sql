


<!DOCTYPE html>
<html>
  <head prefix="og: http://ogp.me/ns# fb: http://ogp.me/ns/fb# githubog: http://ogp.me/ns/fb/githubog#">
    <meta charset='utf-8'>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <title>Databases/13. Database Performance/13.DatabasePerformance-Homework/01,02,03.SQL-Server-tasks.sql at master · skirov/Databases</title>
    <link rel="search" type="application/opensearchdescription+xml" href="/opensearch.xml" title="GitHub" />
    <link rel="fluid-icon" href="https://github.com/fluidicon.png" title="GitHub" />
    <link rel="apple-touch-icon" sizes="57x57" href="/apple-touch-icon-114.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="/apple-touch-icon-114.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="/apple-touch-icon-144.png" />
    <link rel="apple-touch-icon" sizes="144x144" href="/apple-touch-icon-144.png" />
    <link rel="logo" type="image/svg" href="https://github-media-downloads.s3.amazonaws.com/github-logo.svg" />
    <meta property="og:image" content="https://github.global.ssl.fastly.net/images/modules/logos_page/Octocat.png">
    <meta name="hostname" content="fe3.rs.github.com">
    <link rel="assets" href="https://github.global.ssl.fastly.net/">
    <link rel="xhr-socket" href="/_sockets" />
    
    


    <meta name="msapplication-TileImage" content="/windows-tile.png" />
    <meta name="msapplication-TileColor" content="#ffffff" />
    <meta name="selected-link" value="repo_source" data-pjax-transient />
    <meta content="collector.githubapp.com" name="octolytics-host" /><meta content="github" name="octolytics-app-id" /><meta content="3619516" name="octolytics-actor-id" /><meta content="hristian-dimov" name="octolytics-actor-login" /><meta content="93135302d6e6b7a076c73481042676f1708111fbd2e2485a0f8549e62727841f" name="octolytics-actor-hash" />

    
    
    <link rel="icon" type="image/x-icon" href="/favicon.ico" />

    <meta content="authenticity_token" name="csrf-param" />
<meta content="zChDlRW+zzr5VcfTB5tBJ2MSMLkRbbtcpjdP5D9bS8o=" name="csrf-token" />

    <link href="https://github.global.ssl.fastly.net/assets/github-8921d913c104b05dbca482140b50a4899d808da0.css" media="all" rel="stylesheet" type="text/css" />
    <link href="https://github.global.ssl.fastly.net/assets/github2-07b5a2f9ead69e413a4a39b8bf0414aba066b0aa.css" media="all" rel="stylesheet" type="text/css" />
    


      <script src="https://github.global.ssl.fastly.net/assets/frameworks-e8054ad804a1cf9e9849130fee5a4a5487b663ed.js" type="text/javascript"></script>
      <script src="https://github.global.ssl.fastly.net/assets/github-4e41d7724d8be5d39a03f8e6bf2d50a4414b9649.js" type="text/javascript"></script>
      
      <meta http-equiv="x-pjax-version" content="2e2c3f3588b9b3a98ed45f34834b2e61">

        <link data-pjax-transient rel='permalink' href='/skirov/Databases/blob/d67cec80c34b6438e997c49d431d2bf090a7918e/13.%20Database%20Performance/13.DatabasePerformance-Homework/01%2C02%2C03.SQL-Server-tasks.sql'>
  <meta property="og:title" content="Databases"/>
  <meta property="og:type" content="githubog:gitrepository"/>
  <meta property="og:url" content="https://github.com/skirov/Databases"/>
  <meta property="og:image" content="https://github.global.ssl.fastly.net/images/gravatars/gravatar-user-420.png"/>
  <meta property="og:site_name" content="GitHub"/>
  <meta property="og:description" content="Contribute to Databases development by creating an account on GitHub."/>

  <meta name="description" content="Contribute to Databases development by creating an account on GitHub." />

  <meta content="1685052" name="octolytics-dimension-user_id" /><meta content="skirov" name="octolytics-dimension-user_login" /><meta content="11387355" name="octolytics-dimension-repository_id" /><meta content="skirov/Databases" name="octolytics-dimension-repository_nwo" /><meta content="true" name="octolytics-dimension-repository_public" /><meta content="false" name="octolytics-dimension-repository_is_fork" /><meta content="11387355" name="octolytics-dimension-repository_network_root_id" /><meta content="skirov/Databases" name="octolytics-dimension-repository_network_root_nwo" />
  <link href="https://github.com/skirov/Databases/commits/master.atom" rel="alternate" title="Recent Commits to Databases:master" type="application/atom+xml" />

  </head>


  <body class="logged_in page-blob windows vis-public env-production ">

    <div class="wrapper">
      
      
      


      <div class="header header-logged-in true">
  <div class="container clearfix">

    <a class="header-logo-invertocat" href="https://github.com/">
  <span class="mega-octicon octicon-mark-github"></span>
</a>

    <div class="divider-vertical"></div>

      <a href="/notifications" class="notification-indicator tooltipped downwards" title="You have no unread notifications">
    <span class="mail-status all-read"></span>
  </a>
  <div class="divider-vertical"></div>


      <div class="command-bar js-command-bar  in-repository">
          <form accept-charset="UTF-8" action="/search" class="command-bar-form" id="top_search_form" method="get">

<input type="text" data-hotkey=" s" name="q" id="js-command-bar-field" placeholder="Search or type a command" tabindex="1" autocapitalize="off"
    
    data-username="hristian-dimov"
      data-repo="skirov/Databases"
      data-branch="master"
      data-sha="6d481329d9ce05e1b90d7794239726fd6d2ded7a"
  >

    <input type="hidden" name="nwo" value="skirov/Databases" />

    <div class="select-menu js-menu-container js-select-menu search-context-select-menu">
      <span class="minibutton select-menu-button js-menu-target">
        <span class="js-select-button">This repository</span>
      </span>

      <div class="select-menu-modal-holder js-menu-content js-navigation-container">
        <div class="select-menu-modal">

          <div class="select-menu-item js-navigation-item js-this-repository-navigation-item selected">
            <span class="select-menu-item-icon octicon octicon-check"></span>
            <input type="radio" class="js-search-this-repository" name="search_target" value="repository" checked="checked" />
            <div class="select-menu-item-text js-select-button-text">This repository</div>
          </div> <!-- /.select-menu-item -->

          <div class="select-menu-item js-navigation-item js-all-repositories-navigation-item">
            <span class="select-menu-item-icon octicon octicon-check"></span>
            <input type="radio" name="search_target" value="global" />
            <div class="select-menu-item-text js-select-button-text">All repositories</div>
          </div> <!-- /.select-menu-item -->

        </div>
      </div>
    </div>

  <span class="octicon help tooltipped downwards" title="Show command bar help">
    <span class="octicon octicon-question"></span>
  </span>


  <input type="hidden" name="ref" value="cmdform">

</form>
        <ul class="top-nav">
            <li class="explore"><a href="/explore">Explore</a></li>
            <li><a href="https://gist.github.com">Gist</a></li>
            <li><a href="/blog">Blog</a></li>
          <li><a href="https://help.github.com">Help</a></li>
        </ul>
      </div>

    

  

    <ul id="user-links">
      <li>
        <a href="/hristian-dimov" class="name">
          <img height="20" src="https://secure.gravatar.com/avatar/a87bb4017390dc5433de07086d58f1f9?s=140&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png" width="20" /> hristian-dimov
        </a>
      </li>

        <li>
          <a href="/new" id="new_repo" class="tooltipped downwards" title="Create a new repo" aria-label="Create a new repo">
            <span class="octicon octicon-repo-create"></span>
          </a>
        </li>

        <li>
          <a href="/settings/profile" id="account_settings"
            class="tooltipped downwards"
            aria-label="Account settings "
            title="Account settings ">
            <span class="octicon octicon-tools"></span>
          </a>
        </li>
        <li>
          <a class="tooltipped downwards" href="/logout" data-method="post" id="logout" title="Sign out" aria-label="Sign out">
            <span class="octicon octicon-log-out"></span>
          </a>
        </li>

    </ul>


<div class="js-new-dropdown-contents hidden">
  

<ul class="dropdown-menu">
  <li>
    <a href="/new"><span class="octicon octicon-repo-create"></span> New repository</a>
  </li>
  <li>
    <a href="/organizations/new"><span class="octicon octicon-organization"></span> New organization</a>
  </li>



    <li class="section-title">
      <span title="skirov/Databases">This repository</span>
    </li>
    <li>
      <a href="/skirov/Databases/issues/new"><span class="octicon octicon-issue-opened"></span> New issue</a>
    </li>
</ul>

</div>


    
  </div>
</div>

      

      




          <div class="site" itemscope itemtype="http://schema.org/WebPage">
    
    <div class="pagehead repohead instapaper_ignore readability-menu">
      <div class="container">
        

<ul class="pagehead-actions">

    <li class="subscription">
      <form accept-charset="UTF-8" action="/notifications/subscribe" class="js-social-container" data-autosubmit="true" data-remote="true" method="post"><div style="margin:0;padding:0;display:inline"><input name="authenticity_token" type="hidden" value="zChDlRW+zzr5VcfTB5tBJ2MSMLkRbbtcpjdP5D9bS8o=" /></div>  <input id="repository_id" name="repository_id" type="hidden" value="11387355" />

    <div class="select-menu js-menu-container js-select-menu">
        <a class="social-count js-social-count" href="/skirov/Databases/watchers">
          1
        </a>
      <span class="minibutton select-menu-button with-count js-menu-target">
        <span class="js-select-button">
          <span class="octicon octicon-eye-watch"></span>
          Watch
        </span>
      </span>

      <div class="select-menu-modal-holder">
        <div class="select-menu-modal subscription-menu-modal js-menu-content">
          <div class="select-menu-header">
            <span class="select-menu-title">Notification status</span>
            <span class="octicon octicon-remove-close js-menu-close"></span>
          </div> <!-- /.select-menu-header -->

          <div class="select-menu-list js-navigation-container">

            <div class="select-menu-item js-navigation-item selected">
              <span class="select-menu-item-icon octicon octicon-check"></span>
              <div class="select-menu-item-text">
                <input checked="checked" id="do_included" name="do" type="radio" value="included" />
                <h4>Not watching</h4>
                <span class="description">You only receive notifications for discussions in which you participate or are @mentioned.</span>
                <span class="js-select-button-text hidden-select-button-text">
                  <span class="octicon octicon-eye-watch"></span>
                  Watch
                </span>
              </div>
            </div> <!-- /.select-menu-item -->

            <div class="select-menu-item js-navigation-item ">
              <span class="select-menu-item-icon octicon octicon octicon-check"></span>
              <div class="select-menu-item-text">
                <input id="do_subscribed" name="do" type="radio" value="subscribed" />
                <h4>Watching</h4>
                <span class="description">You receive notifications for all discussions in this repository.</span>
                <span class="js-select-button-text hidden-select-button-text">
                  <span class="octicon octicon-eye-unwatch"></span>
                  Unwatch
                </span>
              </div>
            </div> <!-- /.select-menu-item -->

            <div class="select-menu-item js-navigation-item ">
              <span class="select-menu-item-icon octicon octicon-check"></span>
              <div class="select-menu-item-text">
                <input id="do_ignore" name="do" type="radio" value="ignore" />
                <h4>Ignoring</h4>
                <span class="description">You do not receive any notifications for discussions in this repository.</span>
                <span class="js-select-button-text hidden-select-button-text">
                  <span class="octicon octicon-mute"></span>
                  Stop ignoring
                </span>
              </div>
            </div> <!-- /.select-menu-item -->

          </div> <!-- /.select-menu-list -->

        </div> <!-- /.select-menu-modal -->
      </div> <!-- /.select-menu-modal-holder -->
    </div> <!-- /.select-menu -->

</form>
    </li>

  <li>
  
<div class="js-toggler-container js-social-container starring-container ">
  <a href="/skirov/Databases/unstar" class="minibutton with-count js-toggler-target star-button starred upwards" title="Unstar this repo" data-remote="true" data-method="post" rel="nofollow">
    <span class="octicon octicon-star-delete"></span><span class="text">Unstar</span>
  </a>
  <a href="/skirov/Databases/star" class="minibutton with-count js-toggler-target star-button unstarred upwards " title="Star this repo" data-remote="true" data-method="post" rel="nofollow">
    <span class="octicon octicon-star"></span><span class="text">Star</span>
  </a>
  <a class="social-count js-social-count" href="/skirov/Databases/stargazers">0</a>
</div>

  </li>


        <li>
          <a href="/skirov/Databases/fork" class="minibutton with-count js-toggler-target fork-button lighter upwards" title="Fork this repo" rel="nofollow" data-method="post">
            <span class="octicon octicon-git-branch-create"></span><span class="text">Fork</span>
          </a>
          <a href="/skirov/Databases/network" class="social-count">3</a>
        </li>


</ul>

        <h1 itemscope itemtype="http://data-vocabulary.org/Breadcrumb" class="entry-title public">
          <span class="repo-label"><span>public</span></span>
          <span class="mega-octicon octicon-repo"></span>
          <span class="author">
            <a href="/skirov" class="url fn" itemprop="url" rel="author"><span itemprop="title">skirov</span></a></span
          ><span class="repohead-name-divider">/</span><strong
          ><a href="/skirov/Databases" class="js-current-repository js-repo-home-link">Databases</a></strong>

          <span class="page-context-loader">
            <img alt="Octocat-spinner-32" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
          </span>

        </h1>
      </div><!-- /.container -->
    </div><!-- /.repohead -->

    <div class="container">

      <div class="repository-with-sidebar repo-container ">

        <div class="repository-sidebar">
            

<div class="repo-nav repo-nav-full js-repository-container-pjax js-octicon-loaders">
  <div class="repo-nav-contents">
    <ul class="repo-menu">
      <li class="tooltipped leftwards" title="Code">
        <a href="/skirov/Databases" aria-label="Code" class="js-selected-navigation-item selected" data-gotokey="c" data-pjax="true" data-selected-links="repo_source repo_downloads repo_commits repo_tags repo_branches /skirov/Databases">
          <span class="octicon octicon-code"></span> <span class="full-word">Code</span>
          <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>

        <li class="tooltipped leftwards" title="Issues">
          <a href="/skirov/Databases/issues" aria-label="Issues" class="js-selected-navigation-item js-disable-pjax" data-gotokey="i" data-selected-links="repo_issues /skirov/Databases/issues">
            <span class="octicon octicon-issue-opened"></span> <span class="full-word">Issues</span>
            <span class='counter'>0</span>
            <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>        </li>

      <li class="tooltipped leftwards" title="Pull Requests"><a href="/skirov/Databases/pulls" aria-label="Pull Requests" class="js-selected-navigation-item js-disable-pjax" data-gotokey="p" data-selected-links="repo_pulls /skirov/Databases/pulls">
            <span class="octicon octicon-git-pull-request"></span> <span class="full-word">Pull Requests</span>
            <span class='counter'>0</span>
            <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>


        <li class="tooltipped leftwards" title="Wiki">
          <a href="/skirov/Databases/wiki" aria-label="Wiki" class="js-selected-navigation-item " data-pjax="true" data-selected-links="repo_wiki /skirov/Databases/wiki">
            <span class="octicon octicon-book"></span> <span class="full-word">Wiki</span>
            <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>        </li>


    </ul>
    <div class="repo-menu-separator"></div>
    <ul class="repo-menu">

      <li class="tooltipped leftwards" title="Pulse">
        <a href="/skirov/Databases/pulse" aria-label="Pulse" class="js-selected-navigation-item " data-pjax="true" data-selected-links="pulse /skirov/Databases/pulse">
          <span class="octicon octicon-pulse"></span> <span class="full-word">Pulse</span>
          <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>

      <li class="tooltipped leftwards" title="Graphs">
        <a href="/skirov/Databases/graphs" aria-label="Graphs" class="js-selected-navigation-item " data-pjax="true" data-selected-links="repo_graphs repo_contributors /skirov/Databases/graphs">
          <span class="octicon octicon-graph"></span> <span class="full-word">Graphs</span>
          <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>

      <li class="tooltipped leftwards" title="Network">
        <a href="/skirov/Databases/network" aria-label="Network" class="js-selected-navigation-item js-disable-pjax" data-selected-links="repo_network /skirov/Databases/network">
          <span class="octicon octicon-git-branch"></span> <span class="full-word">Network</span>
          <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>

    </ul>

  </div>
</div>

            <div class="only-with-full-nav">
              

  

<div class="clone-url open"
  data-protocol-type="http"
  data-url="/users/set_protocol?protocol_selector=http&amp;protocol_type=clone">
  <h3><strong>HTTPS</strong> clone URL</h3>

  <input type="text" class="clone js-url-field"
         value="https://github.com/skirov/Databases.git" readonly="readonly">

  <span class="js-zeroclipboard url-box-clippy minibutton zeroclipboard-button" data-clipboard-text="https://github.com/skirov/Databases.git" data-copied-hint="copied!" title="copy to clipboard"><span class="octicon octicon-clippy"></span></span>
</div>

  

<div class="clone-url "
  data-protocol-type="ssh"
  data-url="/users/set_protocol?protocol_selector=ssh&amp;protocol_type=clone">
  <h3><strong>SSH</strong> clone URL</h3>

  <input type="text" class="clone js-url-field"
         value="git@github.com:skirov/Databases.git" readonly="readonly">

  <span class="js-zeroclipboard url-box-clippy minibutton zeroclipboard-button" data-clipboard-text="git@github.com:skirov/Databases.git" data-copied-hint="copied!" title="copy to clipboard"><span class="octicon octicon-clippy"></span></span>
</div>

  

<div class="clone-url "
  data-protocol-type="subversion"
  data-url="/users/set_protocol?protocol_selector=subversion&amp;protocol_type=clone">
  <h3><strong>Subversion</strong> checkout URL</h3>

  <input type="text" class="clone js-url-field"
         value="https://github.com/skirov/Databases" readonly="readonly">

  <span class="js-zeroclipboard url-box-clippy minibutton zeroclipboard-button" data-clipboard-text="https://github.com/skirov/Databases" data-copied-hint="copied!" title="copy to clipboard"><span class="octicon octicon-clippy"></span></span>
</div>



<p class="clone-options">You can clone with
    <a href="#" class="js-clone-selector" data-protocol="http">HTTPS</a>,
    <a href="#" class="js-clone-selector" data-protocol="ssh">SSH</a>,
    <a href="#" class="js-clone-selector" data-protocol="subversion">Subversion</a>,
  and <a href="https://help.github.com/articles/which-remote-url-should-i-use">other methods.</a>
</p>


  <a href="github-windows://openRepo/https://github.com/skirov/Databases" class="minibutton sidebar-button">
    <span class="octicon octicon-device-desktop"></span>
    Clone in Desktop
  </a>

                <a href="/skirov/Databases/archive/master.zip"
                   class="minibutton sidebar-button"
                   title="Download this repository as a zip file"
                   rel="nofollow">
                  <span class="octicon octicon-cloud-download"></span>
                  Download ZIP
                </a>
            </div>
        </div><!-- /.repository-sidebar -->

        <div id="js-repo-pjax-container" class="repository-content context-loader-container" data-pjax-container>
          


<!-- blob contrib key: blob_contributors:v21:b3cd4eb8654d4520662d4d676f34f6fd -->
<!-- blob contrib frag key: views10/v8/blob_contributors:v21:b3cd4eb8654d4520662d4d676f34f6fd -->

<p title="This is a placeholder element" class="js-history-link-replace hidden"></p>

<a href="/skirov/Databases/find/master" data-pjax data-hotkey="t" style="display:none">Show File Finder</a>

<div class="file-navigation">
  


<div class="select-menu js-menu-container js-select-menu" >
  <span class="minibutton select-menu-button js-menu-target" data-hotkey="w"
    data-master-branch="master"
    data-ref="master">
    <span class="octicon octicon-git-branch"></span>
    <i>branch:</i>
    <span class="js-select-button">master</span>
  </span>

  <div class="select-menu-modal-holder js-menu-content js-navigation-container" data-pjax>

    <div class="select-menu-modal">
      <div class="select-menu-header">
        <span class="select-menu-title">Switch branches/tags</span>
        <span class="octicon octicon-remove-close js-menu-close"></span>
      </div> <!-- /.select-menu-header -->

      <div class="select-menu-filters">
        <div class="select-menu-text-filter">
          <input type="text" id="context-commitish-filter-field" class="js-filterable-field js-navigation-enable" placeholder="Filter branches/tags">
        </div>
        <div class="select-menu-tabs">
          <ul>
            <li class="select-menu-tab">
              <a href="#" data-tab-filter="branches" class="js-select-menu-tab">Branches</a>
            </li>
            <li class="select-menu-tab">
              <a href="#" data-tab-filter="tags" class="js-select-menu-tab">Tags</a>
            </li>
          </ul>
        </div><!-- /.select-menu-tabs -->
      </div><!-- /.select-menu-filters -->

      <div class="select-menu-list select-menu-tab-bucket js-select-menu-tab-bucket" data-tab-filter="branches">

        <div data-filterable-for="context-commitish-filter-field" data-filterable-type="substring">


            <div class="select-menu-item js-navigation-item selected">
              <span class="select-menu-item-icon octicon octicon-check"></span>
              <a href="/skirov/Databases/blob/master/13.%20Database%20Performance/13.DatabasePerformance-Homework/01,02,03.SQL-Server-tasks.sql" class="js-navigation-open select-menu-item-text js-select-button-text css-truncate-target" data-name="master" data-skip-pjax="true" rel="nofollow" title="master">master</a>
            </div> <!-- /.select-menu-item -->
        </div>

          <div class="select-menu-no-results">Nothing to show</div>
      </div> <!-- /.select-menu-list -->

      <div class="select-menu-list select-menu-tab-bucket js-select-menu-tab-bucket" data-tab-filter="tags">
        <div data-filterable-for="context-commitish-filter-field" data-filterable-type="substring">


        </div>

        <div class="select-menu-no-results">Nothing to show</div>
      </div> <!-- /.select-menu-list -->

    </div> <!-- /.select-menu-modal -->
  </div> <!-- /.select-menu-modal-holder -->
</div> <!-- /.select-menu -->

  <div class="breadcrumb">
    <span class='repo-root js-repo-root'><span itemscope="" itemtype="http://data-vocabulary.org/Breadcrumb"><a href="/skirov/Databases" data-branch="master" data-direction="back" data-pjax="true" itemscope="url"><span itemprop="title">Databases</span></a></span></span><span class="separator"> / </span><span itemscope="" itemtype="http://data-vocabulary.org/Breadcrumb"><a href="/skirov/Databases/tree/master/13.%20Database%20Performance" data-branch="master" data-direction="back" data-pjax="true" itemscope="url"><span itemprop="title">13. Database Performance</span></a></span><span class="separator"> / </span><span itemscope="" itemtype="http://data-vocabulary.org/Breadcrumb"><a href="/skirov/Databases/tree/master/13.%20Database%20Performance/13.DatabasePerformance-Homework" data-branch="master" data-direction="back" data-pjax="true" itemscope="url"><span itemprop="title">13.DatabasePerformance-Homework</span></a></span><span class="separator"> / </span><strong class="final-path">01,02,03.SQL-Server-tasks.sql</strong> <span class="js-zeroclipboard minibutton zeroclipboard-button" data-clipboard-text="13. Database Performance/13.DatabasePerformance-Homework/01,02,03.SQL-Server-tasks.sql" data-copied-hint="copied!" title="copy to clipboard"><span class="octicon octicon-clippy"></span></span>
  </div>
</div>


  
  <div class="commit file-history-tease">
    <img class="main-avatar" height="24" src="https://secure.gravatar.com/avatar/966520867091835f2ce197f742368c53?s=140&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png" width="24" />
    <span class="author"><a href="/skirov" rel="author">skirov</a></span>
    <time class="js-relative-date" datetime="2013-07-19T09:50:17-07:00" title="2013-07-19 09:50:17">July 19, 2013</time>
    <div class="commit-title">
        <a href="/skirov/Databases/commit/80116171ec225abe14aa55ce3b0416c3ca36ec14" class="message" data-pjax="true">commit db performance hw</a>
    </div>

    <div class="participation">
      <p class="quickstat"><a href="#blob_contributors_box" rel="facebox"><strong>1</strong> contributor</a></p>
      
    </div>
    <div id="blob_contributors_box" style="display:none">
      <h2 class="facebox-header">Users who have contributed to this file</h2>
      <ul class="facebox-user-list">
        <li class="facebox-user-list-item">
          <img height="24" src="https://secure.gravatar.com/avatar/966520867091835f2ce197f742368c53?s=140&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png" width="24" />
          <a href="/skirov">skirov</a>
        </li>
      </ul>
    </div>
  </div>


<div id="files" class="bubble">
  <div class="file">
    <div class="meta">
      <div class="info">
        <span class="icon"><b class="octicon octicon-file-text"></b></span>
        <span class="mode" title="File Mode">file</span>
          <span>60 lines (44 sloc)</span>
        <span>2.038 kb</span>
      </div>
      <div class="actions">
        <div class="button-group">
                <a class="minibutton tooltipped leftwards"
                   title="Clicking this button will automatically fork this project so you can edit the file"
                   href="/skirov/Databases/edit/master/13.%20Database%20Performance/13.DatabasePerformance-Homework/01,02,03.SQL-Server-tasks.sql"
                   data-method="post" rel="nofollow">Edit</a>
          <a href="/skirov/Databases/raw/master/13.%20Database%20Performance/13.DatabasePerformance-Homework/01%2C02%2C03.SQL-Server-tasks.sql" class="button minibutton " id="raw-url">Raw</a>
            <a href="/skirov/Databases/blame/master/13.%20Database%20Performance/13.DatabasePerformance-Homework/01%2C02%2C03.SQL-Server-tasks.sql" class="button minibutton ">Blame</a>
          <a href="/skirov/Databases/commits/master/13.%20Database%20Performance/13.DatabasePerformance-Homework/01%2C02%2C03.SQL-Server-tasks.sql" class="button minibutton " rel="nofollow">History</a>
        </div><!-- /.button-group -->
            <a class="minibutton danger empty-icon tooltipped downwards"
               href="/skirov/Databases/delete/master/13.%20Database%20Performance/13.DatabasePerformance-Homework/01,02,03.SQL-Server-tasks.sql"
               title="Fork this project and delete file" data-method="post" rel="nofollow">
            Delete
          </a>
      </div><!-- /.actions -->

    </div>
        <div class="blob-wrapper data type-sql js-blob-data">
      <table class="file-code file-diff">
        <tr class="file-code-line">
          <td class="blob-line-nums">
            <span id="L1" rel="#L1">1</span>
<span id="L2" rel="#L2">2</span>
<span id="L3" rel="#L3">3</span>
<span id="L4" rel="#L4">4</span>
<span id="L5" rel="#L5">5</span>
<span id="L6" rel="#L6">6</span>
<span id="L7" rel="#L7">7</span>
<span id="L8" rel="#L8">8</span>
<span id="L9" rel="#L9">9</span>
<span id="L10" rel="#L10">10</span>
<span id="L11" rel="#L11">11</span>
<span id="L12" rel="#L12">12</span>
<span id="L13" rel="#L13">13</span>
<span id="L14" rel="#L14">14</span>
<span id="L15" rel="#L15">15</span>
<span id="L16" rel="#L16">16</span>
<span id="L17" rel="#L17">17</span>
<span id="L18" rel="#L18">18</span>
<span id="L19" rel="#L19">19</span>
<span id="L20" rel="#L20">20</span>
<span id="L21" rel="#L21">21</span>
<span id="L22" rel="#L22">22</span>
<span id="L23" rel="#L23">23</span>
<span id="L24" rel="#L24">24</span>
<span id="L25" rel="#L25">25</span>
<span id="L26" rel="#L26">26</span>
<span id="L27" rel="#L27">27</span>
<span id="L28" rel="#L28">28</span>
<span id="L29" rel="#L29">29</span>
<span id="L30" rel="#L30">30</span>
<span id="L31" rel="#L31">31</span>
<span id="L32" rel="#L32">32</span>
<span id="L33" rel="#L33">33</span>
<span id="L34" rel="#L34">34</span>
<span id="L35" rel="#L35">35</span>
<span id="L36" rel="#L36">36</span>
<span id="L37" rel="#L37">37</span>
<span id="L38" rel="#L38">38</span>
<span id="L39" rel="#L39">39</span>
<span id="L40" rel="#L40">40</span>
<span id="L41" rel="#L41">41</span>
<span id="L42" rel="#L42">42</span>
<span id="L43" rel="#L43">43</span>
<span id="L44" rel="#L44">44</span>
<span id="L45" rel="#L45">45</span>
<span id="L46" rel="#L46">46</span>
<span id="L47" rel="#L47">47</span>
<span id="L48" rel="#L48">48</span>
<span id="L49" rel="#L49">49</span>
<span id="L50" rel="#L50">50</span>
<span id="L51" rel="#L51">51</span>
<span id="L52" rel="#L52">52</span>
<span id="L53" rel="#L53">53</span>
<span id="L54" rel="#L54">54</span>
<span id="L55" rel="#L55">55</span>
<span id="L56" rel="#L56">56</span>
<span id="L57" rel="#L57">57</span>
<span id="L58" rel="#L58">58</span>
<span id="L59" rel="#L59">59</span>
<span id="L60" rel="#L60">60</span>

          </td>
          <td class="blob-line-code">
                  <div class="highlight"><pre><div class='line' id='LC1'><span class="c1">-- Task 1</span></div><div class='line' id='LC2'><span class="c1">-- Create a table in SQL Server with 10 000 000 log entries (date + text).</span></div><div class='line' id='LC3'><span class="c1">-- Search in the table by date range. Check the speed (without caching).</span></div><div class='line' id='LC4'><br/></div><div class='line' id='LC5'><span class="k">INSERT</span> <span class="k">INTO</span> <span class="n">Logs</span><span class="p">(</span><span class="n">LogDate</span><span class="p">,</span> <span class="n">LogText</span><span class="p">)</span> <span class="k">VALUES</span> <span class="p">(</span><span class="s1">&#39;1990-01-01&#39;</span><span class="p">,</span> <span class="s1">&#39;Sample log &#39;</span><span class="p">);</span></div><div class='line' id='LC6'><br/></div><div class='line' id='LC7'><span class="c1">--Insert records in the format Date | SampleLog1, Date | SampleLog2...</span></div><div class='line' id='LC8'><span class="k">DECLARE</span> <span class="o">@</span><span class="n">Counter</span> <span class="nb">int</span> <span class="o">=</span> <span class="mi">0</span></div><div class='line' id='LC9'><span class="n">WHILE</span> <span class="p">(</span><span class="k">SELECT</span> <span class="k">COUNT</span><span class="p">(</span><span class="o">*</span><span class="p">)</span> <span class="k">FROM</span> <span class="n">Logs</span><span class="p">)</span> <span class="o">&lt;</span> <span class="mi">1000000</span></div><div class='line' id='LC10'><span class="k">BEGIN</span></div><div class='line' id='LC11'>&nbsp;&nbsp;<span class="k">INSERT</span> <span class="k">INTO</span> <span class="n">Logs</span><span class="p">(</span><span class="n">LogDate</span><span class="p">,</span> <span class="n">LogText</span><span class="p">)</span></div><div class='line' id='LC12'>&nbsp;&nbsp;<span class="k">SELECT</span> <span class="n">DATEADD</span><span class="p">(</span><span class="k">MONTH</span><span class="p">,</span> <span class="o">@</span><span class="n">Counter</span> <span class="o">+</span> <span class="mi">3</span><span class="p">,</span> <span class="n">LogDate</span><span class="p">),</span> <span class="n">LogText</span> <span class="o">+</span> <span class="k">CONVERT</span><span class="p">(</span><span class="nb">varchar</span><span class="p">,</span> <span class="o">@</span><span class="n">Counter</span><span class="p">)</span> <span class="k">FROM</span> <span class="n">Logs</span></div><div class='line' id='LC13'>&nbsp;&nbsp;<span class="k">SET</span> <span class="o">@</span><span class="n">Counter</span> <span class="o">=</span> <span class="o">@</span><span class="n">Counter</span> <span class="o">+</span> <span class="mi">1</span></div><div class='line' id='LC14'><span class="k">END</span></div><div class='line' id='LC15'><br/></div><div class='line' id='LC16'><span class="c1">--Empty the SQL Server cache</span></div><div class='line' id='LC17'><span class="k">CHECKPOINT</span><span class="p">;</span> <span class="n">DBCC</span> <span class="n">DROPCLEANBUFFERS</span><span class="p">;</span> </div><div class='line' id='LC18'><br/></div><div class='line' id='LC19'><span class="c1">--Test search by date before adding index</span></div><div class='line' id='LC20'><span class="k">SELECT</span> <span class="n">LogText</span> <span class="k">FROM</span> <span class="n">Logs</span> <span class="k">WHERE</span> <span class="n">LogDate</span> </div><div class='line' id='LC21'>		<span class="k">BETWEEN</span> <span class="k">CONVERT</span><span class="p">(</span><span class="n">datetime</span><span class="p">,</span> <span class="s1">&#39;1990-01-01&#39;</span><span class="p">)</span> <span class="k">AND</span> <span class="k">CONVERT</span><span class="p">(</span><span class="n">datetime</span><span class="p">,</span> <span class="s1">&#39;1995-01-01&#39;</span><span class="p">);</span> <span class="c1">--you must look at the records and change the date to another value, because you cannot go back in time yet :)</span></div><div class='line' id='LC22'><br/></div><div class='line' id='LC23'><br/></div><div class='line' id='LC24'><span class="c1">-- Task 2</span></div><div class='line' id='LC25'><span class="c1">-- Add an index to speed-up the search by date. Test the search speed (after cleaning the cache).</span></div><div class='line' id='LC26'><br/></div><div class='line' id='LC27'><span class="c1">-- Add a index to the date column</span></div><div class='line' id='LC28'><span class="k">CREATE</span> <span class="k">INDEX</span> <span class="n">IDX_OnLogsDateColumn</span> <span class="k">ON</span> <span class="n">Logs</span><span class="p">(</span><span class="n">LogDate</span><span class="p">);</span></div><div class='line' id='LC29'><br/></div><div class='line' id='LC30'><span class="c1">--Empty the SQL Server cache</span></div><div class='line' id='LC31'><span class="k">CHECKPOINT</span><span class="p">;</span> <span class="n">DBCC</span> <span class="n">DROPCLEANBUFFERS</span><span class="p">;</span> </div><div class='line' id='LC32'><br/></div><div class='line' id='LC33'><span class="c1">--Test search by date after adding index</span></div><div class='line' id='LC34'><span class="k">SELECT</span> <span class="n">LogText</span> <span class="k">FROM</span> <span class="n">Logs</span> <span class="k">WHERE</span> <span class="n">LogDate</span> </div><div class='line' id='LC35'>		<span class="k">BETWEEN</span> <span class="k">CONVERT</span><span class="p">(</span><span class="n">datetime</span><span class="p">,</span> <span class="s1">&#39;2013-07-19 11:59:21&#39;</span><span class="p">)</span> <span class="k">AND</span> <span class="k">CONVERT</span><span class="p">(</span><span class="n">datetime</span><span class="p">,</span> <span class="s1">&#39;2013-07-19 11:59:25&#39;</span><span class="p">);</span> <span class="c1">--you must look at the records and change the date to another value, because you cannot go back in time yet :)</span></div><div class='line' id='LC36'><br/></div><div class='line' id='LC37'><br/></div><div class='line' id='LC38'><br/></div><div class='line' id='LC39'><span class="c1">-- Task 3</span></div><div class='line' id='LC40'><span class="c1">-- Add a full text index for the text column. Try to search with and without the full-text index and compare the speed.</span></div><div class='line' id='LC41'><br/></div><div class='line' id='LC42'><span class="k">CREATE</span> <span class="n">FULLTEXT</span> <span class="k">CATALOG</span> <span class="n">LogsFullTextForLogText</span></div><div class='line' id='LC43'><span class="k">WITH</span> <span class="n">ACCENT_SENSITIVITY</span> <span class="o">=</span> <span class="k">OFF</span></div><div class='line' id='LC44'><br/></div><div class='line' id='LC45'><span class="k">CREATE</span> <span class="n">FULLTEXT</span> <span class="k">INDEX</span> <span class="k">ON</span> <span class="n">Logs</span><span class="p">(</span><span class="n">LogText</span><span class="p">)</span></div><div class='line' id='LC46'><span class="k">KEY</span> <span class="k">INDEX</span> <span class="n">PK_Logs</span></div><div class='line' id='LC47'><span class="k">ON</span> <span class="n">LogsFullTextForLogText</span></div><div class='line' id='LC48'><span class="k">WITH</span> <span class="n">CHANGE_TRACKING</span> <span class="n">AUTO</span></div><div class='line' id='LC49'><br/></div><div class='line' id='LC50'><span class="c1">--Empty the SQL Server cache</span></div><div class='line' id='LC51'><span class="k">CHECKPOINT</span><span class="p">;</span> <span class="n">DBCC</span> <span class="n">DROPCLEANBUFFERS</span><span class="p">;</span></div><div class='line' id='LC52'><span class="c1">--Search from full text</span></div><div class='line' id='LC53'><span class="k">SELECT</span> <span class="o">*</span> <span class="k">FROM</span> <span class="n">Logs</span></div><div class='line' id='LC54'><span class="k">WHERE</span> <span class="n">LogText</span> <span class="k">LIKE</span> <span class="s1">&#39;% 1256789&#39;</span></div><div class='line' id='LC55'><br/></div><div class='line' id='LC56'><span class="c1">--Empty the SQL Server cache</span></div><div class='line' id='LC57'><span class="k">CHECKPOINT</span><span class="p">;</span> <span class="n">DBCC</span> <span class="n">DROPCLEANBUFFERS</span><span class="p">;</span></div><div class='line' id='LC58'><span class="c1">--Search from full text</span></div><div class='line' id='LC59'><span class="k">SELECT</span> <span class="o">*</span> <span class="k">FROM</span> <span class="n">Logs</span></div><div class='line' id='LC60'><span class="k">WHERE</span> <span class="k">CONTAINS</span><span class="p">(</span><span class="n">LogText</span><span class="p">,</span><span class="s1">&#39;1256789&#39;</span><span class="p">)</span></div></pre></div>
          </td>
        </tr>
      </table>
  </div>

  </div>
</div>

<a href="#jump-to-line" rel="facebox[.linejump]" data-hotkey="l" class="js-jump-to-line" style="display:none">Jump to Line</a>
<div id="jump-to-line" style="display:none">
  <form accept-charset="UTF-8" class="js-jump-to-line-form">
    <input class="linejump-input js-jump-to-line-field" type="text" placeholder="Jump to line&hellip;" autofocus>
    <button type="submit" class="button">Go</button>
  </form>
</div>

        </div>

      </div><!-- /.repo-container -->
      <div class="modal-backdrop"></div>
    </div><!-- /.container -->
  </div><!-- /.site -->


    </div><!-- /.wrapper -->

      <div class="container">
  <div class="site-footer">
    <ul class="site-footer-links right">
      <li><a href="https://status.github.com/">Status</a></li>
      <li><a href="http://developer.github.com">API</a></li>
      <li><a href="http://training.github.com">Training</a></li>
      <li><a href="http://shop.github.com">Shop</a></li>
      <li><a href="/blog">Blog</a></li>
      <li><a href="/about">About</a></li>

    </ul>

    <a href="/">
      <span class="mega-octicon octicon-mark-github"></span>
    </a>

    <ul class="site-footer-links">
      <li>&copy; 2013 <span title="0.06231s from fe3.rs.github.com">GitHub</span>, Inc.</li>
        <li><a href="/site/terms">Terms</a></li>
        <li><a href="/site/privacy">Privacy</a></li>
        <li><a href="/security">Security</a></li>
        <li><a href="/contact">Contact</a></li>
    </ul>
  </div><!-- /.site-footer -->
</div><!-- /.container -->


    <div class="fullscreen-overlay js-fullscreen-overlay" id="fullscreen_overlay">
  <div class="fullscreen-container js-fullscreen-container">
    <div class="textarea-wrap">
      <textarea name="fullscreen-contents" id="fullscreen-contents" class="js-fullscreen-contents" placeholder="" data-suggester="fullscreen_suggester"></textarea>
          <div class="suggester-container">
              <div class="suggester fullscreen-suggester js-navigation-container" id="fullscreen_suggester"
                 data-url="/skirov/Databases/suggestions/commit">
              </div>
          </div>
    </div>
  </div>
  <div class="fullscreen-sidebar">
    <a href="#" class="exit-fullscreen js-exit-fullscreen tooltipped leftwards" title="Exit Zen Mode">
      <span class="mega-octicon octicon-screen-normal"></span>
    </a>
    <a href="#" class="theme-switcher js-theme-switcher tooltipped leftwards"
      title="Switch themes">
      <span class="octicon octicon-color-mode"></span>
    </a>
  </div>
</div>



    <div id="ajax-error-message" class="flash flash-error">
      <span class="octicon octicon-alert"></span>
      <a href="#" class="octicon octicon-remove-close close ajax-error-dismiss"></a>
      Something went wrong with that request. Please try again.
    </div>

    
  </body>
</html>

