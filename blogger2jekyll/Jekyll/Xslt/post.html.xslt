<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
<xsl:param name="fileType" />
<xsl:param name="includeSummary" />
<xsl:param name="includeDescription" />
<xsl:output method="html" indent="yes"/>
<xsl:template match="/entry">
---
layout: post
published: <xsl:value-of select="./isPublished" />
title: <xsl:value-of select="./title" />
tags: <xsl:call-template name="join"><xsl:with-param name="valueList" select="./category[@scheme='http://www.blogger.com/atom/ns#']/@term"/><xsl:with-param name="separator" select="', '"/></xsl:call-template>    
permalink: /<xsl:value-of select="./permalink" /><xsl:value-of select="$fileType" />
<xsl:if test="$includeDescription='true'">
description: <xsl:value-of select="substring(./description,0,160)" />
</xsl:if>
<xsl:if test="$includeSummary='true'">
summary: <xsl:value-of select="./summary" />
</xsl:if>
---
  <div class="post">
    <h2>{{ page.title }}</h2>
    <strong>{{ page.date | date_to_long_string }}</strong>
    <div>
      <xsl:value-of select="./content" />
    </div>
    {% unless page.tags == empty %}
    {% assign tags_list = page.tags %}
    <p class="tags">
      Tagged: {{ page.tags | join : ', ' }}
    </p>
    {% endunless %}
    <div id="comments">
      <!-- if you use an external commenting system, add the script reference here before processing your export file -->
    </div>
  </div>
  </xsl:template>
  <xsl:template name="join" >
    <xsl:param name="valueList" select="''"/>
    <xsl:param name="separator" select="','"/>
    <xsl:for-each select="$valueList">
      <xsl:choose>
        <xsl:when test="position() = 1">
          <xsl:value-of select="."/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="concat($separator, .) "/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>