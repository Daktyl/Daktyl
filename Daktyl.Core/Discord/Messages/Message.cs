using System;
using Daktyl.Core.Discord.Channels;
using Daktyl.Core.Discord.Embeds;
using Daktyl.Core.Discord.Guilds;
using Daktyl.Core.Discord.Users;

namespace Daktyl.Core.Discord.Messages
{
	// https://discordapp.com/developers/docs/resources/channel#message-object
	public readonly struct Message : IEquatable<Message>
	{
		public Snowflake Id { get; }
		public Snowflake ChannelId { get; }
		public Snowflake GuildId { get; }
		public User Author { get; }
		public GuildMember Member { get; }
		public string Content { get; }
		public DateTime Timestamp { get; }
		public DateTime? EditedTimestamp { get; }
		public bool TTS { get; }
		public bool MentionEveryone { get; }
		public User[] Mentions { get; }
		public Role[] MentionRoles { get; }
		public ChannelMention[] MentionChannels { get; }
		public Attachment[] Attachments { get; }
		public Embed[] Embeds { get; }

		public Reaction[] Reactions { get; }

		//TODO: Nonce
		public bool Pinned { get; }
		public Snowflake? WebhookId { get; }
		public MessageType Type { get; }
		public MessageActivity? Activity { get; }
		public MessageApplication? Application { get; }
		public MessageReference? MessageReference { get; }
		public MessageFlags? Flags { get; }

		public Message(Snowflake id, Snowflake channelId, Snowflake guildId, User author, GuildMember member,
			string content, DateTime timestamp, DateTime? editedTimestamp, bool tts, bool mentionEveryone,
			User[] mentions, Role[] mentionRoles, ChannelMention[] mentionChannels, Attachment[] attachments,
			Embed[] embeds, Reaction[] reactions, bool pinned, Snowflake? webhookId, MessageType type,
			MessageActivity? activity, MessageApplication? application, MessageReference? messageReference,
			MessageFlags? flags)
		{
			Id = id;
			ChannelId = channelId;
			GuildId = guildId;
			Author = author;
			Member = member;
			Content = content;
			Timestamp = timestamp;
			EditedTimestamp = editedTimestamp;
			TTS = tts;
			MentionEveryone = mentionEveryone;
			Mentions = mentions;
			MentionRoles = mentionRoles;
			MentionChannels = mentionChannels;
			Attachments = attachments;
			Embeds = embeds;
			Reactions = reactions;
			Pinned = pinned;
			WebhookId = webhookId;
			Type = type;
			Activity = activity;
			Application = application;
			MessageReference = messageReference;
			Flags = flags;
		}

		public bool Equals(Message other)
		{
			return Id.Equals(other.Id) && ChannelId.Equals(other.ChannelId) && GuildId.Equals(other.GuildId) &&
					Author.Equals(other.Author) && Member.Equals(other.Member) && Content == other.Content &&
					Timestamp.Equals(other.Timestamp) && Nullable.Equals(EditedTimestamp, other.EditedTimestamp) &&
					TTS == other.TTS && MentionEveryone == other.MentionEveryone && Equals(Mentions, other.Mentions) &&
					Equals(MentionRoles, other.MentionRoles) && Equals(MentionChannels, other.MentionChannels) &&
					Equals(Attachments, other.Attachments) && Equals(Embeds, other.Embeds) &&
					Equals(Reactions, other.Reactions) && Pinned == other.Pinned &&
					Nullable.Equals(WebhookId, other.WebhookId) && Type == other.Type &&
					Nullable.Equals(Activity, other.Activity) && Nullable.Equals(Application, other.Application) &&
					Nullable.Equals(MessageReference, other.MessageReference) && Flags == other.Flags;
		}

		public override bool Equals(object obj)
		{
			return obj is Message other && Equals(other);
		}

		public override int GetHashCode()
		{
			var hashCode = new HashCode();
			hashCode.Add(Id);
			hashCode.Add(ChannelId);
			hashCode.Add(GuildId);
			hashCode.Add(Author);
			hashCode.Add(Member);
			hashCode.Add(Content);
			hashCode.Add(Timestamp);
			hashCode.Add(EditedTimestamp);
			hashCode.Add(TTS);
			hashCode.Add(MentionEveryone);
			hashCode.Add(Mentions);
			hashCode.Add(MentionRoles);
			hashCode.Add(MentionChannels);
			hashCode.Add(Attachments);
			hashCode.Add(Embeds);
			hashCode.Add(Reactions);
			hashCode.Add(Pinned);
			hashCode.Add(WebhookId);
			hashCode.Add((int) Type);
			hashCode.Add(Activity);
			hashCode.Add(Application);
			hashCode.Add(MessageReference);
			hashCode.Add(Flags);
			return hashCode.ToHashCode();
		}

		public static bool operator ==(Message left, Message right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Message left, Message right)
		{
			return !left.Equals(right);
		}
	}
}