using DNet.Structures.Channels;
using System;
using System.Linq;
using DNet.Core;
using System.Collections.Generic;

namespace DNet.Builders
{
    public class RichEmbed : AutoJsonSerialize, IBuilder<Embed>
    {
        private Embed embed;

        public RichEmbed()
        {
            this.embed = new Embed();
        }

        public RichEmbed AddField(string name, string value, bool inline = false)
        {
            // TODO: Names can be null?
            if (value == null)
            {
                throw new Exception("Embed field values cannot be empty");
            }
            else if (this.embed.Fields == null)
            {
                this.embed.Fields = new EmbedField[] { };
            }

            List<EmbedField> edit = this.embed.Fields.ToList();

            edit.Add(new EmbedField()
            {
                Name = name,
                Value = value,
                Inline = inline
            });

            this.embed.Fields = edit.ToArray();

            return this;
        }

        public RichEmbed SetDescription(string description)
        {
            this.embed.Description = description;

            return this;
        }

        public RichEmbed SetColor(int color)
        {
            this.embed.Color = color;

            return this;
        }

        public RichEmbed SetFooter(EmbedFooter footer)
        {
            this.embed.Footer = footer;

            return this;
        }

        public RichEmbed SetImage(EmbedImage image)
        {
            this.embed.Image = image;

            return this;
        }

        public RichEmbed SetThumbnail(EmbedThumbnail thumbnail)
        {
            this.embed.Thumbnail = thumbnail;

            return this;
        }

        public RichEmbed SetTitle(string title)
        {
            this.embed.Title = title;

            return this;
        }

        public RichEmbed SetTimestamp(string timestamp)
        {
            this.embed.Timestamp = timestamp;

            return this;
        }

        public RichEmbed SetVideo(EmbedVideo video)
        {
            this.embed.Video = video;

            return this;
        }

        public Embed Build()
        {
            return this.embed;
        }
    }
}
